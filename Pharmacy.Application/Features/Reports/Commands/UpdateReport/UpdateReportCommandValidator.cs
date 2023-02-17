using FluentValidation;
using Pharmacy.Application.Features.Reports.Constants;

namespace Pharmacy.Application.Features.Reports.Commands.UpdateReport;

public class UpdateReportCommandValidator : AbstractValidator<UpdateReportCommand>
{
    public UpdateReportCommandValidator()
    {
        RuleFor(x=>x.CustomerId)
            .NotEmpty()
            .WithMessage(ReportMessages.CustomerIdRequired);
        
        RuleFor(x=>x.PurchaseId)
            .NotEmpty()
            .WithMessage(ReportMessages.PurchaseIdRequired);
        
        RuleFor(x=>x.SaleId)
            .NotEmpty()
            .WithMessage(ReportMessages.SaleIdRequired);
    }
}