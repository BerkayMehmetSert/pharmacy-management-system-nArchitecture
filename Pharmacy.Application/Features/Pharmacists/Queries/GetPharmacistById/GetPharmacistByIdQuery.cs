using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Pharmacists.Dto;
using Pharmacy.Application.Features.Pharmacists.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Pharmacists.Queries.GetPharmacistById;

public class GetPharmacistByIdQuery : IRequest<PharmacistDto>
{
    public int Id { get; set; }

    public class GetPharmacistByIdQueryHandler : IRequestHandler<GetPharmacistByIdQuery, PharmacistDto>
    {
        private readonly IPharmacistRepository _pharmacistRepository;
        private readonly IMapper _mapper;
        private readonly PharmacistBusinessRules _rules;

        public GetPharmacistByIdQueryHandler(IPharmacistRepository pharmacistRepository, IMapper mapper,
            PharmacistBusinessRules rules)
        {
            _pharmacistRepository = pharmacistRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<PharmacistDto> Handle(GetPharmacistByIdQuery request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfPharmacistExists(request.Id);
            
            var pharmacist = await _pharmacistRepository.GetAsync(x => x.Id == request.Id);
            var result = _mapper.Map<PharmacistDto>(pharmacist);
            return result;
        }
    }
}