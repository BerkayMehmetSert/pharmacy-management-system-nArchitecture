namespace Pharmacy.Application.Features.Medicines.Constants;

public static class MedicineMessages
{
    public const string MedicineNotFound = "Medicine not found";
    public const string MedicineListIsEmpty = "Medicine list is empty";
    
    public const string DescriptionRequired = "Description is required";
    public const string DescriptionMinLength = "Description must be at least 2 characters";
    public const string PriceRequired = "Price is required";
    public const string PriceMinValue = "Price must be greater than 0";
}