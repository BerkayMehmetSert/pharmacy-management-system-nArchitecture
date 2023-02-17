using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Pharmacy.Application.Features.Sales.Constants;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Sales.Rules;

public class SaleBusinessRules : BaseBusinessRules
{
    private readonly ISaleRepository _saleRepository;

    public SaleBusinessRules(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }
    
    public async Task CheckIfSaleExists(int id)
    {
        var sale = await _saleRepository.GetAsync(x=>x.Id== id);
        if (sale == null) throw new BusinessException(SaleMessages.SaleNotFound);
    }
    
    public void CheckIfSaleListIsEmpty(IPaginate<Sale> sales)
    {
        if (sales.Items.Count == 0) throw new BusinessException(SaleMessages.SaleListEmpty);
    }
}