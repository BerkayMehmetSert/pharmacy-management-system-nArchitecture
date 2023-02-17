using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Reports.Dto;
using Pharmacy.Application.Features.Reports.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Reports.Commands.UpdateReport;

public class UpdateReportCommand : IRequest<UpdatedReportDto>
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int PurchaseId { get; set; }
    public int SaleId { get; set; }

    public class UpdateReportCommandHandler : IRequestHandler<UpdateReportCommand, UpdatedReportDto>
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;
        private readonly ReportBusinessRules _rules;

        public UpdateReportCommandHandler(IReportRepository reportRepository, IMapper mapper, ReportBusinessRules rules)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<UpdatedReportDto> Handle(UpdateReportCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfReportExists(request.Id);

            var report = await _reportRepository.GetAsync(x => x.Id == request.Id);
            report!.CustomerId = request.CustomerId;
            report.PurchaseId = request.PurchaseId;
            report.SaleId = request.SaleId;

            var updatedReport = await _reportRepository.UpdateAsync(report);
            var result = _mapper.Map<UpdatedReportDto>(updatedReport);
            return result;
        }
    }
}