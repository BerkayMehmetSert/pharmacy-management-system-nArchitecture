namespace Pharmacy.Application.Features.Categories.Constants;

public static class CategoryMessages
{
    public const string CategoryNameAlreadyExists = "Category name already exists";
    public const string CategoryIdDoesNotExist = "Category id does not exist";
    public const string CategoryListIsEmpty = "Category list is empty";

    public const string NameIsRequired = "Name is required";
    public const string CategoryInvalidNameLength = "Category name must be between 2 and 50 characters";
}