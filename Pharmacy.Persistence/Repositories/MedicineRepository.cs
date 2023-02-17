using Core.Persistence.Repositories;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;
using Pharmacy.Persistence.Contexts;

namespace Pharmacy.Persistence.Repositories;

public class MedicineRepository : EfRepositoryBase<Medicine, BaseDbContext>, IMedicineRepository
{
    public MedicineRepository(BaseDbContext context) : base(context)
    {
    }
}