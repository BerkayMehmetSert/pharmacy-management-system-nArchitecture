using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Categories.Dto;
using Pharmacy.Application.Features.Categories.Rules;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<CreatedCategoryDto>
{
    public string? Name { get; set; }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _rules;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper,
            CategoryBusinessRules rules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<CreatedCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfCategoryNameExists(request.Name);

            var requestToEntity = _mapper.Map<Category>(request);
            var addedCategory = await _categoryRepository.AddAsync(requestToEntity);
            var result = _mapper.Map<CreatedCategoryDto>(addedCategory);

            return result;
        }
    }
}