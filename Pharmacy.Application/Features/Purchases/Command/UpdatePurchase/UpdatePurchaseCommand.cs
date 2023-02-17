using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Purchases.Dto;
using Pharmacy.Application.Features.Purchases.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Purchases.Command.UpdatePurchase;

public class UpdatePurchaseCommand : IRequest<UpdatedPurchaseDto>
{
    public int Id { get; set; }
    public int MedicineId { get; set; }
    public int CustomerId { get; set; }
    public double Amount { get; set; }

    public class UpdatePurchaseCommandHandler : IRequestHandler<UpdatePurchaseCommand, UpdatedPurchaseDto>
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;
        private readonly PurchaseBusinessRules _rules;

        public UpdatePurchaseCommandHandler(IPurchaseRepository purchaseRepository, IMapper mapper,
            PurchaseBusinessRules rules)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<UpdatedPurchaseDto> Handle(UpdatePurchaseCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfPurchaseExists(request.Id);
            
            var purchase = await _purchaseRepository.GetAsync(x => x.Id == request.Id);
            purchase!.MedicineId = request.MedicineId;
            purchase.CustomerId = request.CustomerId;
            purchase.Amount = request.Amount;
            
            var updatedPurchase = await _purchaseRepository.UpdateAsync(purchase);
            var result = _mapper.Map<UpdatedPurchaseDto>(updatedPurchase);
            return result;
        }
    }
}