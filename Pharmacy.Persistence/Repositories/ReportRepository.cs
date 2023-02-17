using Core.Persistence.Repositories;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;
using Pharmacy.Persistence.Contexts;

namespace Pharmacy.Persistence.Repositories;

public class ReportRepository : EfRepositoryBase<Report, BaseDbContext>, IReportRepository
{
    public ReportRepository(BaseDbContext context) : base(context)
    {
    }
}