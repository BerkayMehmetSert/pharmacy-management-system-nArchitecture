using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Pharmacy.Application.Features.Pharmacists.Constants;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Pharmacists.Rules;

public class PharmacistBusinessRules : BaseBusinessRules
{
    private readonly IPharmacistRepository _pharmacistRepository;

    public PharmacistBusinessRules(IPharmacistRepository pharmacistRepository)
    {
        _pharmacistRepository = pharmacistRepository;
    }

    public async Task CheckIfPharmacistExists(string email)
    {
        var pharmacist = await _pharmacistRepository.GetAsync(x => x.Email == email);
        if (pharmacist != null) throw new BusinessException(PharmacistMessages.PharmacistAlreadyExists);
    }
    
    public async Task CheckIfPharmacistExists(int id)
    {
        var pharmacist = await _pharmacistRepository.GetAsync(x => x.Id == id);
        if (pharmacist == null) throw new BusinessException(PharmacistMessages.PharmacistNotFound);
    }
    
    public void CheckIfPharmacistListIsEmpty(IPaginate<Pharmacist> pharmacists)
    {
        if (pharmacists.Items.Count == 0) throw new BusinessException(PharmacistMessages.PharmacistListIsEmpty);
    }
}