using Core.Persistence.Paging;
using Pharmacy.Application.Features.Purchases.Dto;

namespace Pharmacy.Application.Features.Purchases.Models;

public class PurchaseListModel : BasePageableModel
{
    public IList<PurchaseListDto> Items { get; set; }
}