using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Pharmacy.Application.Features.Medicines.Constants;
using Pharmacy.Application.Services.MedicineService;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Medicines.Rules;

public class MedicineBusinessRules : BaseBusinessRules
{
    private readonly IMedicineService _medicineService;

    public MedicineBusinessRules(IMedicineService medicineService)
    {
        _medicineService = medicineService;
    }

    public async Task CheckIfMedicineExists(int id)
    {
        var medicine = await _medicineService.GetMedicineById(id);

        if (medicine == null) throw new BusinessException(MedicineMessages.MedicineNotFound);
    }
    
    public void CheckIfMedicineListIsEmpty(IPaginate<Medicine> medicines)
    {
        if (medicines.Items.Count == 0) throw new BusinessException(MedicineMessages.MedicineListIsEmpty);
    }
}