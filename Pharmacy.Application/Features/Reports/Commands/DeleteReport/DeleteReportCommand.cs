using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Reports.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Reports.Commands.DeleteReport;

public class DeleteReportCommand : IRequest<DeleteReportCommand>
{
    public int Id { get; set; }

    public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommand, DeleteReportCommand>
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;
        private readonly ReportBusinessRules _rules;

        public DeleteReportCommandHandler(IReportRepository reportRepository, IMapper mapper, ReportBusinessRules rules)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<DeleteReportCommand> Handle(DeleteReportCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfReportExists(request.Id);
            var report = await _reportRepository.GetAsync(x => x.Id == request.Id);

            var deletedReport = await _reportRepository.DeleteAsync(report!);
            var result = _mapper.Map<DeleteReportCommand>(deletedReport);
            return result;
        }
    }
}