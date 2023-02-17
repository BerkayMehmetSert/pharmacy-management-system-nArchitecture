using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Reports.Dto;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Reports.Commands.CreateReport;

public class CreateReportCommand : IRequest<CreatedReportDto>
{
    public int CustomerId { get; set; }
    public int PurchaseId { get; set; }
    public int SaleId { get; set; }

    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, CreatedReportDto>
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public CreateReportCommandHandler(IReportRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task<CreatedReportDto> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var requestToEntity = _mapper.Map<Report>(request);
            
            var report = await _reportRepository.AddAsync(requestToEntity);
            var result = _mapper.Map<CreatedReportDto>(report);
            return result;
        }
    }
}