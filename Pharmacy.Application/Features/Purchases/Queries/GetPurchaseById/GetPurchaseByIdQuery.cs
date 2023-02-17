using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Purchases.Dto;
using Pharmacy.Application.Features.Purchases.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Purchases.Queries.GetPurchaseById;

public class GetPurchaseByIdQuery : IRequest<PurchaseDto>
{
    public int Id { get; set; }

    public class GetPurchaseByIdQueryHandler : IRequestHandler<GetPurchaseByIdQuery, PurchaseDto>
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;
        private readonly PurchaseBusinessRules _rules;

        public GetPurchaseByIdQueryHandler(IPurchaseRepository purchaseRepository, IMapper mapper,
            PurchaseBusinessRules rules)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<PurchaseDto> Handle(GetPurchaseByIdQuery request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfPurchaseExists(request.Id);
            
            var purchase = await _purchaseRepository.GetAsync(x => x.Id == request.Id);
            var result = _mapper.Map<PurchaseDto>(purchase);
            return result;
        }
    }
}