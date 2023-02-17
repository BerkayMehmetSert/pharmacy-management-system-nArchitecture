using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Features.Customers.Models;
using Pharmacy.Application.Features.Customers.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Customers.Queries.GetListCustomerQuery;

public class GetListCustomerQuery : IRequest<CustomerModelList>
{
    public PageRequest? PageRequest { get; set; }

    public class GetAllCustomerQueryHandler : IRequestHandler<GetListCustomerQuery, CustomerModelList>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CustomerBusinessRules _rules;

        public GetAllCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper,
            CustomerBusinessRules rules)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<CustomerModelList> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetListAsync(
                include: x =>
                    x.Include(y => y.Sales)
                        .Include(y => y.Reports)
                        .Include(y => y.Purchases),
                size: request.PageRequest.PageSize,
                index: request.PageRequest.Page
            );

            _rules.CheckIfCategoryListEmpty(customers);
            
            var result = _mapper.Map<CustomerModelList>(customers);
            return result;
        }
    }
}