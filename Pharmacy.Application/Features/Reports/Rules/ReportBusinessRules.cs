using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Pharmacy.Application.Features.Reports.Constants;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Reports.Rules;

public class ReportBusinessRules : BaseBusinessRules
{
    private readonly IReportRepository _reportRepository;

    public ReportBusinessRules(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public async Task CheckIfReportExists(int id)
    {
        var report = await _reportRepository.GetAsync(x => x.Id == id);
        if (report == null) throw new BusinessException(ReportMessages.ReportNotFound);
    }
    
    public void  CheckIfReportListIsEmpty(IPaginate<Report> reports)
    {
        if (reports.Items.Count == 0) throw new BusinessException(ReportMessages.ReportListIsEmpty);
    }

}