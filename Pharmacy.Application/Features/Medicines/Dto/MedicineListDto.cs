namespace Pharmacy.Application.Features.Medicines.Dto;

public class MedicineListDto : BaseMedicineDto
{
    public IList<MedicineSaleDto> Sales { get; set; }
    public IList<MedicinePurchaseDto> Purchases { get; set; }
}