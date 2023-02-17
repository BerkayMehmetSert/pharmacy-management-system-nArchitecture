using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Sales.Dto;
using Pharmacy.Application.Services.MedicineService;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Application.Services.SaleService;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Sales.Commands.CreateSale;

public class CreateSaleCommand : IRequest<CreatedSaleDto>
{
    public int CustomerId { get; set; }
    public int MedicineId { get; set; }
    public int PharmacistId { get; set; }
    public int PurchaseId { get; set; }
    public int Count { get; set; }

    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, CreatedSaleDto>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly ISaleService _saleService;
        private readonly IMedicineService _medicineService;

        public CreateSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper, ISaleService saleService,
            IMedicineService medicineService)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _saleService = saleService;
            _medicineService = medicineService;
        }

        public async Task<CreatedSaleDto> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var medicine = await _medicineService.GetMedicineById(request.MedicineId);
            var requestToEntity = _mapper.Map<Sale>(request);
            requestToEntity.TotalPrice = _saleService.CalculateTotalPrice(request.Count, medicine.Price);

            var sale = await _saleRepository.AddAsync(requestToEntity);
            var result = _mapper.Map<CreatedSaleDto>(sale);
            return result;
        }
    }
}