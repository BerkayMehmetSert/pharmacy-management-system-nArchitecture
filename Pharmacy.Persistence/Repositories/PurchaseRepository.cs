using Core.Persistence.Repositories;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;
using Pharmacy.Persistence.Contexts;

namespace Pharmacy.Persistence.Repositories;

public class PurchaseRepository : EfRepositoryBase<Purchase, BaseDbContext>, IPurchaseRepository
{
    public PurchaseRepository(BaseDbContext context) : base(context)
    {
    }
}