using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Pharmacists.Dto;
using Pharmacy.Application.Features.Pharmacists.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Pharmacists.Commands.UpdatePharmacist;

public class UpdatePharmacistCommand : IRequest<UpdatedPharmacistDto>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public string ContactAddress { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public class UpdatePharmacistCommandHandler : IRequestHandler<UpdatePharmacistCommand, UpdatedPharmacistDto>
    {
        private readonly IPharmacistRepository _pharmacistRepository;
        private readonly IMapper _mapper;
        private readonly PharmacistBusinessRules _rules;

        public UpdatePharmacistCommandHandler(IPharmacistRepository pharmacistRepository, IMapper mapper,
            PharmacistBusinessRules rules)
        {
            _pharmacistRepository = pharmacistRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<UpdatedPharmacistDto> Handle(UpdatePharmacistCommand request,
            CancellationToken cancellationToken)
        {
            await _rules.CheckIfPharmacistExists(request.Id);

            var pharmacist = await _pharmacistRepository.GetAsync(x => x.Id == request.Id);
            pharmacist!.FirstName = request.FirstName;
            pharmacist.LastName = request.LastName;
            pharmacist.Gender = request.Gender;
            pharmacist.Age = request.Age;
            pharmacist.ContactAddress = request.ContactAddress;
            pharmacist.Email = request.Email;
            pharmacist.Password = request.Password;

           var updatedPharmacist = await _pharmacistRepository.UpdateAsync(pharmacist);
            var result = _mapper.Map<UpdatedPharmacistDto>(updatedPharmacist);
            return result;
        }
    }
}