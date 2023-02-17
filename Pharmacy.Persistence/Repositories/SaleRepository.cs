using Core.Persistence.Repositories;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;
using Pharmacy.Persistence.Contexts;

namespace Pharmacy.Persistence.Repositories;

public class SaleRepository : EfRepositoryBase<Sale, BaseDbContext>, ISaleRepository
{
    public SaleRepository(BaseDbContext context) : base(context)
    {
    }
}