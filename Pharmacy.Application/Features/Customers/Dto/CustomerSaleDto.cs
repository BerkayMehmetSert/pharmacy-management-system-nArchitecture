using Core.Application.Dtos;

namespace Pharmacy.Application.Features.Customers.Dto;

public class CustomerSaleDto : IDto
{
    public int MedicineId { get; set; }
    public int PharmacistId { get; set; }
    public int PurchaseId { get; set; }
    public int Count { get; set; }
    public double TotalPrice { get; set; }
}