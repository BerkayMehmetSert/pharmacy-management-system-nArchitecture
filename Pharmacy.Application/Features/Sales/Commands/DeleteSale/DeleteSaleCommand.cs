using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Sales.Dto;
using Pharmacy.Application.Features.Sales.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Sales.Commands.DeleteSale;

public class DeleteSaleCommand : IRequest<UpdatedSaleDto>
{
    public int Id { get; set; }

    public class DeleteSaleCommandHandler : IRequestHandler<DeleteSaleCommand, UpdatedSaleDto>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly SaleBusinessRules _rules;

        public DeleteSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper, SaleBusinessRules rules)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<UpdatedSaleDto> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfSaleExists(request.Id);
            
            var sale = await _saleRepository.GetAsync(x=>x.Id == request.Id);
            var deletedSale = await _saleRepository.DeleteAsync(sale!);
            var result = _mapper.Map<UpdatedSaleDto>(deletedSale);
            return result;
        }
    }
}