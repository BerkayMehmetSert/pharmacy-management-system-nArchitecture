using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Pharmacy.Application.Features.Purchases.Constants;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Purchases.Rules;

public class PurchaseBusinessRules : BaseBusinessRules
{
    private readonly IPurchaseRepository _purchaseRepository;

    public PurchaseBusinessRules(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public async Task CheckIfPurchaseExists(int id)
    {
        var purchase = await _purchaseRepository.GetAsync(x => x.Id == id);
        if (purchase == null) throw new BusinessException(PurchaseMessages.PurchaseNotFound);
    }

    public void CheckIfPurchaseListIsEmpty(IPaginate<Purchase> purchases)
    {
        if (purchases.Items.Count == 0) throw new BusinessException(PurchaseMessages.PurchaseListIsEmpty);
    }
}