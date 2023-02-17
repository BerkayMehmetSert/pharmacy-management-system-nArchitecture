using Core.Application.Dtos;

namespace Pharmacy.Application.Features.Medicines.Dto;

public class MedicinePurchaseDto : IDto
{
    public int CustomerId { get; set; }
    public double Amount { get; set; }
}