using AutoMapper;
using Core.Persistence.Paging;
using Pharmacy.Application.Features.Categories.Commands.CreateCategory;
using Pharmacy.Application.Features.Categories.Commands.DeleteCategory;
using Pharmacy.Application.Features.Categories.Commands.UpdateCategory;
using Pharmacy.Application.Features.Categories.Dto;
using Pharmacy.Application.Features.Categories.Models;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Categories.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, CreatedCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
        CreateMap<Category, UpdatedCategoryDto>().ReverseMap();
        CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
        CreateMap<Category, DeletedCategoryDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryListDto>().ReverseMap();
        CreateMap<IPaginate<Category>, CategoryModelList>().ReverseMap();
    }
}