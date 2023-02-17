using Core.Persistence.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Services.Repositories;

public interface ICustomerRepository : IAsyncRepository<Customer>
{

}