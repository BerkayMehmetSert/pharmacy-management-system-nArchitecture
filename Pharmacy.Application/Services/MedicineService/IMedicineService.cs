using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Services.MedicineService;

public interface IMedicineService
{
    public Task<Medicine> GetMedicineById(int id);
}