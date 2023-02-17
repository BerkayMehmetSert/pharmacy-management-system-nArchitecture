using AutoMapper;
using Core.Persistence.Repositories;
using MediatR;
using Pharmacy.Application.Features.Customers.Dto;
using Pharmacy.Application.Features.Customers.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQuery : IRequest<CustomerDto>
{
    public int Id { get; set; }

    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CustomerBusinessRules _rules;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper,
            CustomerBusinessRules rules)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            await _rules.CheckCustomerExists(request.Id);
            
            var customer = await _customerRepository.GetAsync(x=>x.Id==request.Id);
            var result = _mapper.Map<CustomerDto>(customer);
            return result;
        }
    }
}