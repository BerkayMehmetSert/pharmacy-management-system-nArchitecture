using FluentValidation;
using Pharmacy.Application.Features.Categories.Constants;

namespace Pharmacy.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
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