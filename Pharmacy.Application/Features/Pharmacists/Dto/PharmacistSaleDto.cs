using Core.Application.Dtos;

namespace Pharmacy.Application.Features.Pharmacists.Dto;

public class PharmacistSaleDto : IDto
{
    public int CustomerId { get; set; }
    public int MedicineId { get; set; }
    public int PurchaseId { get; set; }
    public int Count { get; set; }
    public double TotalPrice { get; set; }
}