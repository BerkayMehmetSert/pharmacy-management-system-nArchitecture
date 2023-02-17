using FluentValidation;
using Pharmacy.Application.Features.Categories.Commands.CreateCategory;
using Pharmacy.Application.Features.Categories.Constants;

namespace Pharmacy.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(CategoryMessages.NameIsRequired);

        RuleFor(x => x.Name)
            .MinimumLength(2)
            .MaximumLength(50)
            .WithMessage(CategoryMessages.CategoryInvalidNameLength);
    }
}