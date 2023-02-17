using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Customers.Dto;
using Pharmacy.Application.Features.Customers.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommand : IRequest<UpdatedCustomerDto>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public string ContactAddress { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdatedCustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CustomerBusinessRules _rules;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper,
            CustomerBusinessRules rules)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<UpdatedCustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckCustomerExists(request.Id);
            
            var customer = await _customerRepository.GetAsync(x => x.Id == request.Id);
            
            customer!.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Gender = request.Gender;
            customer.Age = request.Age;
            customer.ContactAddress = request.ContactAddress;
            customer.Email = request.Email;
            customer.Password = request.Password;

            var updatedCustomer = await _customerRepository.UpdateAsync(customer);
            var result = _mapper.Map<UpdatedCustomerDto>(updatedCustomer);
            return result;
        }
    }
}