using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Pharmacy.Application.Features.Sales.Models;
using Pharmacy.Application.Features.Sales.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Sales.Queries.GetSaleList;

public class GetSaleListQuery : IRequest<SaleListModel>
{
    public PageRequest? PageRequest { get; set; }

    public class GetSaleListQueryHandler : IRequestHandler<GetSaleListQuery, SaleListModel>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly SaleBusinessRules _rules;

        public GetSaleListQueryHandler(ISaleRepository saleRepository, IMapper mapper, SaleBusinessRules rules)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<SaleListModel> Handle(GetSaleListQuery request, CancellationToken cancellationToken)
        {
            var sales = await _saleRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize
            );
            
             _rules.CheckIfSaleListIsEmpty(sales);
            
             var result = _mapper.Map<SaleListModel>(sales);
            return result;
        }
    }
}