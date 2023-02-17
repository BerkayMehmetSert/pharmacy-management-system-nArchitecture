using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Customers.Dto;
using Pharmacy.Application.Features.Customers.Rules;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommand : IRequest<CreatedCustomerDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public string ContactAddress { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreatedCustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CustomerBusinessRules _rules;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper,
            CustomerBusinessRules rules)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<CreatedCustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfCustomerExistsByEmail(request.Email);
            var requestToEntity = _mapper.Map<Customer>(request);
            var addedCustomer = await _customerRepository.AddAsync(requestToEntity);
            var result = _mapper.Map<CreatedCustomerDto>(addedCustomer);
            return result;
        }
    }
}