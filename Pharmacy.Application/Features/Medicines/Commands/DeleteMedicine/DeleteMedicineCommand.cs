using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Medicines.Dto;
using Pharmacy.Application.Features.Medicines.Rules;
using Pharmacy.Application.Services.MedicineService;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Medicines.Commands.DeleteMedicine;

public class DeleteMedicineCommand : IRequest<DeletedMedicineDto>
{
    public int Id { get; set; }

    public class DeleteMedicineCommandHandler : IRequestHandler<DeleteMedicineCommand, DeletedMedicineDto>
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;
        private readonly MedicineBusinessRules _rules;

        public DeleteMedicineCommandHandler(IMedicineRepository medicineRepository, IMapper mapper,
            MedicineBusinessRules rules, IMedicineService medicineService)
        {
            _medicineRepository = medicineRepository;
            _mapper = mapper;
            _rules = rules;
            _medicineService = medicineService;
        }

        public async Task<DeletedMedicineDto> Handle(DeleteMedicineCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfMedicineExists(request.Id);
            
            var medicine = await _medicineService.GetMedicineById(request.Id);
            var deletedMedicine = await _medicineRepository.DeleteAsync(medicine!);
            var result = _mapper.Map<DeletedMedicineDto>(deletedMedicine);
            return result;
        }
    }
}