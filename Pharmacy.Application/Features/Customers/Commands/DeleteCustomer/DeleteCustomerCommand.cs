using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Customers.Dto;
using Pharmacy.Application.Features.Customers.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommand : IRequest<DeletedCustomerDto>
{
    public int Id { get; set; }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeletedCustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CustomerBusinessRules _rules;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper,
            CustomerBusinessRules rules)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _rules = rules;
        }
        
        public async Task<DeletedCustomerDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckCustomerExists(request.Id);
            var customer = await _customerRepository.GetAsync(x => x.Id == request.Id);

            var deletedCustomer = await _customerRepository.DeleteAsync(customer!);

            var result = _mapper.Map<DeletedCustomerDto>(deletedCustomer);
            return result;
        }
    }
}