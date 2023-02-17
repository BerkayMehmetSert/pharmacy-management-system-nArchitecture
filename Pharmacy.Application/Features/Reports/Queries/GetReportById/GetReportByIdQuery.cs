using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Reports.Dto;
using Pharmacy.Application.Features.Reports.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Reports.Queries.GetReportById;

public class GetReportByIdQuery : IRequest<ReportDto>
{
    public int Id { get; set; }

    public class GetReportByIdQueryHandler : IRequestHandler<GetReportByIdQuery, ReportDto>
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;
        private readonly ReportBusinessRules _rules;

        public GetReportByIdQueryHandler(IReportRepository reportRepository, IMapper mapper, ReportBusinessRules rules)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<ReportDto> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfReportExists(request.Id);
            var report = await _reportRepository.GetAsync(x => x.Id == request.Id);
            var result = _mapper.Map<ReportDto>(report);
            return result;
        }
    }
}