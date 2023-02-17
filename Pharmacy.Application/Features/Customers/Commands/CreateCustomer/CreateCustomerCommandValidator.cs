using FluentValidation;
using Pharmacy.Application.Features.Customers.Constants;

namespace Pharmacy.Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x=>x.FirstName)
            .NotEmpty()
            .WithMessage(CustomerMessages.CustomerFirstNameRequired);
        
        RuleFor(x=>x.FirstName)
            .MinimumLength(2)
            .MaximumLength(50)
            .WithMessage(CustomerMessages.CustomerInvalidFirstNameLength);
        
        RuleFor(x=>x.LastName)
            .NotEmpty()
            .WithMessage(CustomerMessages.CustomerLastNameRequired);
        
        RuleFor(x=>x.LastName)
            .MinimumLength(2)
            .MaximumLength(50)
            .WithMessage(CustomerMessages.CustomerInvalidLastNameLength);
        
        RuleFor(x=>x.Email)
            .NotEmpty()
            .WithMessage(CustomerMessages.CustomerEmailRequired);
        
        RuleFor(x=>x.Email)
            .EmailAddress()
            .WithMessage(CustomerMessages.CustomerInvalidEmail);
        
        RuleFor(x=>x.Password)
            .NotEmpty()
            .WithMessage(CustomerMessages.CustomerPasswordRequired);
        
        RuleFor(x=>x.Password)
            .MinimumLength(6)
            .MaximumLength(50)
            .WithMessage(CustomerMessages.CustomerInvalidPasswordLength);
        
    }
}