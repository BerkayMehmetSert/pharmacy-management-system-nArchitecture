using FluentValidation;
using Pharmacy.Application.Features.Medicines.Constants;

namespace Pharmacy.Application.Features.Medicines.Commands.UpdateMedicine;

public class UpdateMedicineCommandValidator : AbstractValidator<UpdateMedicineCommand>
{
    public UpdateMedicineCommandValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage(MedicineMessages.DescriptionRequired);
        
        RuleFor(x=>x.Description)
            .MinimumLength(2)
            .WithMessage(MedicineMessages.DescriptionMinLength);
        
        RuleFor(x => x.Price)
            .NotEmpty()
            .WithMessage(MedicineMessages.PriceRequired);
        
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage(MedicineMessages.PriceMinValue);
    }
}