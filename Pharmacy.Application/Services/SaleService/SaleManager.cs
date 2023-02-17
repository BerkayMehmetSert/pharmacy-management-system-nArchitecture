
namespace Pharmacy.Application.Services.SaleService;

public class SaleManager : ISaleService
{

    public double CalculateTotalPrice(int count, double price)
    {
        const double tax = 0.8;
        var totalPrice = (count * price) + ((count * price) * tax);
        return totalPrice;
    }
}