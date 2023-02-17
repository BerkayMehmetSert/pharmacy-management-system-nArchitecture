using Core.Application.Dtos;

namespace Pharmacy.Application.Features.Purchases.Dto;

public class PurchaseSaleDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int MedicineId { get; set; }
    public int PharmacistId { get; set; }
    public int Count { get; set; }
    public double TotalPrice { get; set; }
}