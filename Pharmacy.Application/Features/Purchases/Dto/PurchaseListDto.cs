namespace Pharmacy.Application.Features.Purchases.Dto;

public class PurchaseListDto : BasePurchaseDto
{
    public IList<PurchaseSaleDto> Sales { get; set; }
}