using Core.Application.Dtos;

namespace Pharmacy.Application.Features.Reports.Dto;

public class BaseReportDto: IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int PurchaseId { get; set; }
    public int SaleId { get; set; }
}