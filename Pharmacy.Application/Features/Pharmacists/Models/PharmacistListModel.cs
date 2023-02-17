using Core.Persistence.Paging;
using Pharmacy.Application.Features.Pharmacists.Dto;

namespace Pharmacy.Application.Features.Pharmacists.Models;

public class PharmacistListModel : BasePageableModel
{
    public IList<PharmacistListDto> Items { get; set; }
}