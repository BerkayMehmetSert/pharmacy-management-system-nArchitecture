using Core.Application.Dtos;

namespace Pharmacy.Application.Features.Customers.Dto;

public class CustomerReportDto : IDto
{
    public int PurchaseId { get; set; }
    public int SaleId { get; set; }
}