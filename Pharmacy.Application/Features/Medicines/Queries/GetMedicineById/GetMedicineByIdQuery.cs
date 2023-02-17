using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Medicines.Dto;
using Pharmacy.Application.Features.Medicines.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Medicines.Queries.GetMedicineById;

public class GetMedicineByIdQuery : IRequest<MedicineDto>
{
    public int Id { get; set; }

    public class GetMedicineByIdQueryHandler : IRequestHandler<GetMedicineByIdQuery, MedicineDto>
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IMapper _mapper;
        private readonly MedicineBusinessRules _rules;

        public GetMedicineByIdQueryHandler(IMedicineRepository medicineRepository, IMapper mapper,
            MedicineBusinessRules rules)
        {
            _medicineRepository = medicineRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<MedicineDto> Handle(GetMedicineByIdQuery request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfMedicineExists(request.Id);

            var medicine = await _medicineRepository.GetAsync(x => x.Id == request.Id);

            var result = _mapper.Map<MedicineDto>(medicine);
            return result;
        }
    }
}