using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Pharmacists.Dto;
using Pharmacy.Application.Features.Pharmacists.Rules;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Pharmacists.Commands.CreatePharmacist;

public class CreatePharmacistCommand : IRequest<CreatedPharmacistDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public string ContactAddress { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public class CreatePharmacistCommandHandler : IRequestHandler<CreatePharmacistCommand, CreatedPharmacistDto>
    {
        private readonly IPharmacistRepository _pharmacistRepository;
        private readonly IMapper _mapper;
        private readonly PharmacistBusinessRules _rules;

        public CreatePharmacistCommandHandler(IPharmacistRepository pharmacistRepository, IMapper mapper,
            PharmacistBusinessRules rules)
        {
            _pharmacistRepository = pharmacistRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<CreatedPharmacistDto> Handle(CreatePharmacistCommand request,
            CancellationToken cancellationToken)
        {
            await _rules.CheckIfPharmacistExists(request.Email);

            var requestToEntity = _mapper.Map<Pharmacist>(request);
            var pharmacist = await _pharmacistRepository.AddAsync(requestToEntity);
            var result = _mapper.Map<CreatedPharmacistDto>(pharmacist);
            
            return result;
        }
    }
}