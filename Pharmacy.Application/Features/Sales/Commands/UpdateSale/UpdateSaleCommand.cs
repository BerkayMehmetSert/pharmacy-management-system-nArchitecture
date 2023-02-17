using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Sales.Dto;
using Pharmacy.Application.Features.Sales.Rules;
using Pharmacy.Application.Services.MedicineService;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Application.Services.SaleService;

namespace Pharmacy.Application.Features.Sales.Commands.UpdateSale;

public class UpdateSaleCommand : IRequest<UpdatedSaleDto>
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int MedicineId { get; set; }
    public int PharmacistId { get; set; }
    public int PurchaseId { get; set; }
    public int Count { get; set; }

    public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, UpdatedSaleDto>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleService _saleService;
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;
        private readonly SaleBusinessRules _rules;

        public UpdateSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper, SaleBusinessRules rules,
            ISaleService saleService, IMedicineService medicineService)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _rules = rules;
            _saleService = saleService;
            _medicineService = medicineService;
        }

        public async Task<UpdatedSaleDto> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfSaleExists(request.Id);
            var medicine =await _medicineService.GetMedicineById(request.MedicineId);
            
            var sale = await _saleRepository.GetAsync(x => x.Id == request.Id);
            sale!.CustomerId = request.CustomerId;
            sale.MedicineId = request.MedicineId;
            sale.PharmacistId = request.PharmacistId;
            sale.PurchaseId = request.PurchaseId;
            sale.Count = request.Count;
            sale.TotalPrice = _saleService.CalculateTotalPrice(sale.Count, medicine.Price);

            var updatedSale = await _saleRepository.UpdateAsync(sale);
            var result = _mapper.Map<UpdatedSaleDto>(updatedSale);
            return result;
        }
    }
}