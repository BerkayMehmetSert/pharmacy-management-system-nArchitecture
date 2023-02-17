using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Purchases.Dto;
using Pharmacy.Application.Features.Purchases.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Purchases.Command.DeletePurchase;

public class DeletePurchaseCommand : IRequest<DeletedPurchaseDto>
{
    public int Id { get; set; }

    public class DeletePurchaseCommandHandler : IRequestHandler<DeletePurchaseCommand, DeletedPurchaseDto>
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;
        private readonly PurchaseBusinessRules _rules;

        public DeletePurchaseCommandHandler(IPurchaseRepository purchaseRepository, IMapper mapper,
            PurchaseBusinessRules rules)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<DeletedPurchaseDto> Handle(DeletePurchaseCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfPurchaseExists(request.Id);
            var purchase = await _purchaseRepository.GetAsync(x => x.Id == request.Id);
            await _purchaseRepository.DeleteAsync(purchase!);
            var result = _mapper.Map<DeletedPurchaseDto>(purchase);
            return result;
        }
    }
}