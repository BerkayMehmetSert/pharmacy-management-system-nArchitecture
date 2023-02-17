using Core.Persistence.Paging;
using Pharmacy.Application.Features.Sales.Dto;

namespace Pharmacy.Application.Features.Sales.Models;

public class SaleListModel : BasePageableModel
{
    public IList<SaleListDto> Items { get; set; }
}