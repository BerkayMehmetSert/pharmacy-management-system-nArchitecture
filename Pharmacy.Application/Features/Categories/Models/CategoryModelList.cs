using Core.Persistence.Paging;
using Pharmacy.Application.Features.Categories.Dto;

namespace Pharmacy.Application.Features.Categories.Models;

public class CategoryModelList : BasePageableModel
{
    public IList<CategoryListDto> Items { get; set; }
}