using FluentValidation;
using Pharmacy.Application.Features.Purchases.Constants;

namespace Pharmacy.Application.Features.Purchases.Command.UpdatePurchase;

public class UpdatePurchaseCommandValidator : AbstractValidator<UpdatePurchaseCommand>
{
    public UpdatePurchaseCommandValidator()
    {
        RuleFor(x => x.Amount)
            .NotEmpty()
            .WithMessage(PurchaseMessages.AmountRequired);
        
        RuleFor(x=>x.Amount)
            .GreaterThan(0)
            .WithMessage(PurchaseMessages.AmountMinValue);
    }
}