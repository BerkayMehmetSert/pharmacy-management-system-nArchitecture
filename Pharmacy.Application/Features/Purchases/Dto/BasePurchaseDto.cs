using Core.Application.Dtos;

namespace Pharmacy.Application.Features.Purchases.Dto;

public class BasePurchaseDto : IDto
{
    public int Id { get; set; }
    public int MedicineId { get; set; }
    public int CustomerId { get; set; }
    public double Amount { get; set; }
}