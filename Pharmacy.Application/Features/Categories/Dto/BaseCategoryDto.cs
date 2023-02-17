using Core.Application.Dtos;

namespace Pharmacy.Application.Features.Categories.Dto;

public class BaseCategoryDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}