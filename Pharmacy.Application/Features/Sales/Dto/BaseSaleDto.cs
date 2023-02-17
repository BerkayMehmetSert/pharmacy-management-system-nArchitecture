using Core.Application.Dtos;

namespace Pharmacy.Application.Features.Sales.Dto;

public class BaseSaleDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int MedicineId { get; set; }
    public int PharmacistId { get; set; }
    public int PurchaseId { get; set; }
    public int Count { get; set; }
    public double TotalPrice { get; set; }
    
}