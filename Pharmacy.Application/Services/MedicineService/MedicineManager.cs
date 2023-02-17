using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Services.MedicineService;

public class MedicineManager : IMedicineService
{
    private readonly IMedicineRepository _medicineRepository;

    public MedicineManager(IMedicineRepository medicineRepository)
    {
        _medicineRepository = medicineRepository;
    }

    public async Task<Medicine> GetMedicineById(int id)
    {
        var result = await _medicineRepository.GetAsync(x => x.Id == id);
        return result!;
    }
}