using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Persistence.Contexts;
using Pharmacy.Persistence.Repositories;

namespace Pharmacy.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("PharmacyConnectionString")));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IMedicineRepository, MedicineRepository>();
        services.AddScoped<IPharmacistRepository, PharmacistRepository>();
        services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();

        return services;
    }
}