using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Pharmacy.Application.Features.Reports.Models;
using Pharmacy.Application.Features.Reports.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Reports.Queries.GetReportList;

public class GetReportListQuery : IRequest<ReportListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetReportListQueryHandler : IRequestHandler<GetReportListQuery, ReportListModel>
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;
        private readonly ReportBusinessRules _rules;

        public GetReportListQueryHandler(IReportRepository reportRepository, IMapper mapper, ReportBusinessRules rules)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<ReportListModel> Handle(GetReportListQuery request, CancellationToken cancellationToken)
        {
            var reports = await _reportRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize
            );

            _rules.CheckIfReportListIsEmpty(reports);

            var result = _mapper.Map<ReportListModel>(reports);
            return result;
        }
    }
}