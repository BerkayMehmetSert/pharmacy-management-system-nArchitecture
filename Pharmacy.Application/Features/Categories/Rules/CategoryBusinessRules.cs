using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Pharmacy.Application.Features.Categories.Constants;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Categories.Rules;

public class CategoryBusinessRules : BaseBusinessRules
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryBusinessRules(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task CheckIfCategoryNameExists(string? name)
    {
        var category = await _categoryRepository.GetAsync(x => x.Name == name);
        if (category != null)
        {
            throw new BusinessException(CategoryMessages.CategoryNameAlreadyExists);
        }
    }

    public async Task CheckIfCategoryIdExists(int id)
    {
        var category = await _categoryRepository.GetAsync(x => x.Id == id);
        if (category == null)
        {
            throw new BusinessException(CategoryMessages.CategoryIdDoesNotExist);
        }
    }

    public void CheckIfCategoryListEmpty(IPaginate<Category> categories)
    {
        if (categories == null) throw new BusinessException(CategoryMessages.CategoryListIsEmpty);
    }
}