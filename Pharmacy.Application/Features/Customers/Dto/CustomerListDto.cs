namespace Pharmacy.Application.Features.Customers.Dto;

public class CustomerListDto : BaseCustomerDto
{
    public IList<CustomerSaleDto> Sales { get; set; }
    public IList<CustomerPurchaseDto> Purchases { get; set; }
    public IList<CustomerReportDto> Reports { get; set; }
}