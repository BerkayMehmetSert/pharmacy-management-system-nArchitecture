using Core.Persistence.Repositories;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;
using Pharmacy.Persistence.Contexts;

namespace Pharmacy.Persistence.Repositories;

public class CategoryRepository : EfRepositoryBase<Category, BaseDbContext>, ICategoryRepository
{
    public CategoryRepository(BaseDbContext context) : base(context)
    {
    }
}