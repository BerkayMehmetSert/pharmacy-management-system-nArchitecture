using Core.Persistence.Paging;
using Pharmacy.Application.Features.Reports.Dto;

namespace Pharmacy.Application.Features.Reports.Models;

public class ReportListModel : BasePageableModel
{
    public IList<ReportListDto> Items { get; set; }
}