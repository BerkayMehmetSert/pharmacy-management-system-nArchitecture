using Core.Application.Dtos;

namespace Pharmacy.Application.Features.Medicines.Dto;

public class MedicineSaleDto : IDto
{
    public int CustomerId { get; set; }
    public int PharmacistId { get; set; }
    public int PurchaseId { get; set; }
    public int Count { get; set; }
    public double TotalPrice { get; set; }
}