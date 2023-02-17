using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Sales.Dto;
using Pharmacy.Application.Features.Sales.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Sales.Queries.GetSaleById;

public class GetSaleByIdQuery : IRequest<SaleDto>
{
    public int Id { get; set; }

    public class GetSaleByIdQueryHandler : IRequestHandler<GetSaleByIdQuery, SaleDto>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly SaleBusinessRules _rules;

        public GetSaleByIdQueryHandler(ISaleRepository saleRepository, IMapper mapper, SaleBusinessRules rules)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<SaleDto> Handle(GetSaleByIdQuery request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfSaleExists(request.Id);
            
            var sale = await _saleRepository.GetAsync(x => x.Id == request.Id);
            var result = _mapper.Map<SaleDto>(sale);
            return result;
        }
    }
}