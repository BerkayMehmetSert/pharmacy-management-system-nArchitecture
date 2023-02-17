using Core.Persistence.Paging;
using Pharmacy.Application.Features.Customers.Dto;

namespace Pharmacy.Application.Features.Customers.Models;

public class CustomerModelList : BasePageableModel
{
    public IList<CustomerListDto> Items { get; set; }
}