using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Pharmacists.Dto;
using Pharmacy.Application.Features.Pharmacists.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Pharmacists.Commands.DeletePharmacist;

public class DeletePharmacistCommand : IRequest<DeletedPharmacistDto>
{
    public int Id { get; set; }

    public class DeletePharmacistCommandHandler : IRequestHandler<DeletePharmacistCommand, DeletedPharmacistDto>
    {
        private readonly IPharmacistRepository _pharmacistRepository;
        private readonly IMapper _mapper;
        private readonly PharmacistBusinessRules _rules;

        public DeletePharmacistCommandHandler(IPharmacistRepository pharmacistRepository, IMapper mapper,
            PharmacistBusinessRules rules)
        {
            _pharmacistRepository = pharmacistRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<DeletedPharmacistDto> Handle(DeletePharmacistCommand request,
            CancellationToken cancellationToken)
        {
            await _rules.CheckIfPharmacistExists(request.Id);

            var pharmacist = await _pharmacistRepository.GetAsync(x => x.Id == request.Id);
            await _pharmacistRepository.DeleteAsync(pharmacist!);
            
            var result = _mapper.Map<DeletedPharmacistDto>(pharmacist);
            return result;
        }
    }
}