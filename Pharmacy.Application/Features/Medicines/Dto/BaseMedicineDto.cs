using Core.Application.Dtos;

namespace Pharmacy.Application.Features.Medicines.Dto;

public class BaseMedicineDto : IDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}