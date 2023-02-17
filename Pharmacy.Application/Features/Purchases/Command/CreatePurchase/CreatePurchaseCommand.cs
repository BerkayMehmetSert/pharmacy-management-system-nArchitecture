using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Purchases.Dto;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Purchases.Command.CreatePurchase;

public class CreatePurchaseCommand : IRequest<CreatedPurchaseDto>
{
    public int MedicineId { get; set; }
    public int CustomerId { get; set; }
    public double Amount { get; set; }

    public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, CreatedPurchaseDto>
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;

        public CreatePurchaseCommandHandler(IPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        public async Task<CreatedPurchaseDto> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var requestToEntity = _mapper.Map<Purchase>(request);
            var entity = await _purchaseRepository.AddAsync(requestToEntity);
            var result = _mapper.Map<CreatedPurchaseDto>(entity);
            return result;
        }
    }
}