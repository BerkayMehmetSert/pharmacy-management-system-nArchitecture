namespace Pharmacy.Application.Features.Customers.Constants;

public static class CustomerMessages
{
    public const string CustomerAlreadyExistsByEmail = "Customer already exists with this email.";
    public const string CustomerNotFound = "Customer not found.";
    public const string CustomerListEmpty = "Customer list is empty.";

    public const string CustomerFirstNameRequired = "Customer first name is required.";
    public const string CustomerInvalidFirstNameLength = "Customer first name must be between 2 and 50 characters.";
    public const string CustomerLastNameRequired = "Customer last name is required.";
    public const string CustomerInvalidLastNameLength = "Customer last name must be between 2 and 50 characters.";
    public const string CustomerEmailRequired = "Customer email is required.";
    public const string CustomerInvalidEmail = "Customer email is invalid.";
    public const string CustomerPasswordRequired = "Customer password is required.";
    public const string CustomerInvalidPasswordLength = "Customer password must be between 6 and 50 characters.";
}