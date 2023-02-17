using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Categories.Dto;
using Pharmacy.Application.Features.Categories.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public int Id { get; set; }

    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _rules;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper,
            CategoryBusinessRules rules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfCategoryIdExists(request.Id);
            
            var category = await _categoryRepository.GetAsync(x => x.Id == request.Id);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            
            return categoryDto;
        }
    }
}