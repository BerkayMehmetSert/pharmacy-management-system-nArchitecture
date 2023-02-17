using FluentValidation;
using Pharmacy.Application.Features.Pharmacists.Constants;

namespace Pharmacy.Application.Features.Pharmacists.Commands.CreatePharmacist;

public class CreatePharmacistCommandValidator : AbstractValidator<CreatePharmacistCommand>
{
    public CreatePharmacistCommandValidator()
    {
        RuleFor(x=>x.FirstName)
            .NotEmpty()
            .WithMessage(PharmacistMessages.PharmacistFirstNameRequired);
        
        RuleFor(x=>x.FirstName)
            .MinimumLength(2)
            .MaximumLength(50)
            .WithMessage(PharmacistMessages.PharmacistInvalidFirstNameLength);
        
        RuleFor(x=>x.LastName)
            .NotEmpty()
            .WithMessage(PharmacistMessages.PharmacistLastNameRequired);
        
        RuleFor(x=>x.LastName)
            .MinimumLength(2)
            .MaximumLength(50)
            .WithMessage(PharmacistMessages.PharmacistInvalidLastNameLength);
        
        RuleFor(x=>x.Email)
            .NotEmpty()
            .WithMessage(PharmacistMessages.PharmacistEmailRequired);
        
        RuleFor(x=>x.Email)
            .EmailAddress()
            .WithMessage(PharmacistMessages.PharmacistInvalidEmail);
        
        RuleFor(x=>x.Password)
            .NotEmpty()
            .WithMessage(PharmacistMessages.PharmacistPasswordRequired);
        
        RuleFor(x=>x.Password)
            .MinimumLength(6)
            .MaximumLength(50)
            .WithMessage(PharmacistMessages.PharmacistInvalidPasswordLength);
    }
}