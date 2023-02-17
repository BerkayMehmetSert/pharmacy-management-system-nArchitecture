using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Features.Purchases.Models;
using Pharmacy.Application.Features.Purchases.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Purchases.Queries.GetPurchaseList;

public class GetPurchaseListQuery : IRequest<PurchaseListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetPurchaseListQueryHandler : IRequestHandler<GetPurchaseListQuery, PurchaseListModel>
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;
        private readonly PurchaseBusinessRules _rules;

        public GetPurchaseListQueryHandler(IPurchaseRepository purchaseRepository, IMapper mapper,
            PurchaseBusinessRules rules)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<PurchaseListModel> Handle(GetPurchaseListQuery request, CancellationToken cancellationToken)
        {
            var purchases = await _purchaseRepository.GetListAsync(
                include: x => x.Include(y => y.Sales),
                size: request.PageRequest.PageSize,
                index: request.PageRequest.Page
            );

            _rules.CheckIfPurchaseListIsEmpty(purchases);

            var result = _mapper.Map<PurchaseListModel>(purchases);
            return result;
        }
    }
}