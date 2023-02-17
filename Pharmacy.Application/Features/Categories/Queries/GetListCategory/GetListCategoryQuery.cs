using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Pharmacy.Application.Features.Categories.Models;
using Pharmacy.Application.Features.Categories.Rules;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Categories.Queries.GetListCategory;

public class GetListCategoryQuery : IRequest<CategoryModelList>
{
    public PageRequest? PageRequest { get; set; }

    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, CategoryModelList>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _rules;

        public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper,
            CategoryBusinessRules rules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<CategoryModelList> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetListAsync(
                index: request.PageRequest!.Page,
                size: request.PageRequest.PageSize
            );

            _rules.CheckIfCategoryListEmpty(categories);
            
            var categoryModelList = _mapper.Map<CategoryModelList>(categories);
            return categoryModelList;
        }
    }
}