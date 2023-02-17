using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Categories.Dto;
using Pharmacy.Application.Features.Categories.Rules;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<UpdatedCategoryDto>
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdatedCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _rules;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper,
            CategoryBusinessRules rules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<UpdatedCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfCategoryIdExists(request.Id);
            
            var category = await _categoryRepository.GetAsync(x => x.Id == request.Id);
            category!.Name = request.Name;
            
            var updatedCategory = _categoryRepository.Update(category);
            var categoryToDto = _mapper.Map<UpdatedCategoryDto>(updatedCategory);

            return categoryToDto;
        }
    }
}