using Core.Persistence.Repositories;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;
using Pharmacy.Persistence.Contexts;

namespace Pharmacy.Persistence.Repositories;

public class CustomerRepository : EfRepositoryBase<Customer, BaseDbContext>, ICustomerRepository
{
    public CustomerRepository(BaseDbContext context) : base(context)
    {
    }
}