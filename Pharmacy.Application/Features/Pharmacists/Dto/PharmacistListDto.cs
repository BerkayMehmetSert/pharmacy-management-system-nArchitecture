namespace Pharmacy.Application.Features.Pharmacists.Dto;

public class PharmacistListDto : BasePharmacistDto
{
    public IList<PharmacistSaleDto> Sales { get; set; }
}