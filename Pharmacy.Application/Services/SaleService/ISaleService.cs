using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Services.SaleService;

public interface ISaleService
{
    public double CalculateTotalPrice(int count ,double price);
}