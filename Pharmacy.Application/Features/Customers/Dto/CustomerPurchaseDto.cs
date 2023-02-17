using Core.Application.Dtos;

namespace Pharmacy.Application.Features.Customers.Dto;

public class CustomerPurchaseDto : IDto
{
    public int MedicineId { get; set; }
    public double Amount { get; set; }
}