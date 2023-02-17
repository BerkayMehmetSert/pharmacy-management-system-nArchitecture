using Core.Persistence.Repositories;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;
using Pharmacy.Persistence.Contexts;

namespace Pharmacy.Persistence.Repositories;

public class PharmacistRepository : EfRepositoryBase<Pharmacist, BaseDbContext>, IPharmacistRepository
{
    public PharmacistRepository(BaseDbContext context) : base(context)
    {
    }
}