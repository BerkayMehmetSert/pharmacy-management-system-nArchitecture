using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Features.Pharmacists.Models;
using Pharmacy.Application.Features.Pharmacists.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Pharmacists.Queries.GetPharmacistList;

public class GetPharmacistListQuery : IRequest<PharmacistListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetPharmacistListQueryHandler : IRequestHandler<GetPharmacistListQuery, PharmacistListModel>
    {
        private readonly IPharmacistRepository _pharmacistRepository;
        private readonly IMapper _mapper;
        private readonly PharmacistBusinessRules _rules;

        public GetPharmacistListQueryHandler(IPharmacistRepository pharmacistRepository, IMapper mapper,
            PharmacistBusinessRules rules)
        {
            _pharmacistRepository = pharmacistRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<PharmacistListModel> Handle(GetPharmacistListQuery request,
            CancellationToken cancellationToken)
        {
            var pharmacist = await _pharmacistRepository.GetListAsync(
                include: x => x.Include(y => y.Sales),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize
            );

            _rules.CheckIfPharmacistListIsEmpty(pharmacist);

            var result = _mapper.Map<PharmacistListModel>(pharmacist);
            return result;
        }
    }
}