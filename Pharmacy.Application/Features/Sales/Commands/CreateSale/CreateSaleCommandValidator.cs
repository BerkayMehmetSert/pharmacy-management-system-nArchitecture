using FluentValidation;
using Pharmacy.Application.Features.Sales.Constants;

namespace Pharmacy.Application.Features.Sales.Commands.CreateSale;

public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidator()
    {
        RuleFor(x=>x.CustomerId)
            .NotEmpty()
            .WithMessage(SaleMessages.CustomerIdRequired);
        
        RuleFor(x=>x.MedicineId)
            .NotEmpty()
            .WithMessage(SaleMessages.MedicineIdRequired);
        
        RuleFor(x=>x.PharmacistId)
            .NotEmpty()
            .WithMessage(SaleMessages.PharmacistIdRequired);
        
        RuleFor(x=>x.PurchaseId)
            .NotEmpty()
            .WithMessage(SaleMessages.PurchaseIdRequired);
        
        RuleFor(x=>x.Count)
            .NotEmpty()
            .WithMessage(SaleMessages.CountRequired);
        
        RuleFor(x=>x.Count)
            .GreaterThan(0)
            .WithMessage(SaleMessages.CountGreaterThanZero);
    }
}