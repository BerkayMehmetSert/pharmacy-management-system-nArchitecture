using Core.Persistence.Paging;
using Pharmacy.Application.Features.Reports.Commands.CreateReport;
using Pharmacy.Application.Features.Reports.Commands.DeleteReport;
using Pharmacy.Application.Features.Reports.Commands.UpdateReport;
using Pharmacy.Application.Features.Reports.Dto;
using Pharmacy.Application.Features.Reports.Models;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Reports.Profile;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<Report, CreateReportCommand>().ReverseMap();
        CreateMap<Report, CreatedReportDto>().ReverseMap();
        CreateMap<Report, UpdateReportCommand>().ReverseMap();
        CreateMap<Report, UpdatedReportDto>().ReverseMap();
        CreateMap<Report, DeleteReportCommand>().ReverseMap();
        CreateMap<Report, DeletedReportDto>().ReverseMap();
        CreateMap<Report, ReportDto>().ReverseMap();
        CreateMap<Report, ReportListDto>().ReverseMap();
        CreateMap<IPaginate<Report>, ReportListModel>().ReverseMap();
    }
}