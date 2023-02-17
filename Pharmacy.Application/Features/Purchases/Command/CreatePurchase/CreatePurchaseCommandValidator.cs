using FluentValidation;
using Pharmacy.Application.Features.Purchases.Constants;

namespace Pharmacy.Application.Features.Purchases.Command.CreatePurchase;

public class CreatePurchaseCommandValidator : AbstractValidator<CreatePurchaseCommand>
{
    public CreatePurchaseCommandValidator()
    {
        RuleFor(x => x.Amount)
            .NotEmpty()
            .WithMessage(PurchaseMessages.AmountRequired);
        
        RuleFor(x=>x.Amount)
            .GreaterThan(0)
            .WithMessage(PurchaseMessages.AmountMinValue);
    }
}