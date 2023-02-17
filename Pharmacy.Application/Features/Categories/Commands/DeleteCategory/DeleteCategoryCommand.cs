using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Categories.Dto;
using Pharmacy.Application.Features.Categories.Rules;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest<DeletedCategoryDto>
{
    public int Id { get; set; }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeletedCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _rules;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper,
            CategoryBusinessRules rules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<DeletedCategoryDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfCategoryIdExists(request.Id);

            var category = await _categoryRepository.GetAsync(x => x.Id == request.Id);
            var deletedCategory = await _categoryRepository.DeleteAsync(category!);
            var categoryToDto = _mapper.Map<DeletedCategoryDto>(deletedCategory);

            return categoryToDto;
        }
    }
}