namespace Pharmacy.Application.Features.Pharmacists.Constants;

public static class PharmacistMessages
{
    public const string PharmacistAlreadyExists = "Pharmacist already exists";
    public const string PharmacistNotFound = "Pharmacist not found";
    public const string PharmacistListIsEmpty = "Pharmacists not found";
    
    public const string PharmacistFirstNameRequired = "First name is required";
    public const string PharmacistInvalidFirstNameLength = "First name must be between 2 and 50 characters";
    
    public const string PharmacistLastNameRequired = "Last name is required";
    public const string PharmacistInvalidLastNameLength = "Last name must be between 2 and 50 characters";
    
    public const string PharmacistEmailRequired = "Email is required";
    public const string PharmacistInvalidEmail = "Email is invalid";
    
    public const string PharmacistPasswordRequired = "Password is required";
    public const string PharmacistInvalidPasswordLength = "Password must be between 6 and 50 characters";
    
}