using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Medicines.Dto;
using Pharmacy.Application.Features.Medicines.Rules;
using Pharmacy.Application.Services.MedicineService;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Medicines.Commands.UpdateMedicine;

public class UpdateMedicineCommand : IRequest<UpdatedMedicineDto>
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }

    public class UpdateMedicineCommandHandler : IRequestHandler<UpdateMedicineCommand, UpdatedMedicineDto>
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;
        private readonly MedicineBusinessRules _rules;

        public UpdateMedicineCommandHandler(IMedicineRepository medicineRepository, IMapper mapper,
            MedicineBusinessRules rules, IMedicineService medicineService)
        {
            _medicineRepository = medicineRepository;
            _mapper = mapper;
            _rules = rules;
            _medicineService = medicineService;
        }

        public async Task<UpdatedMedicineDto> Handle(UpdateMedicineCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfMedicineExists(request.Id);

            var medicine = await _medicineService.GetMedicineById(request.Id);
            medicine!.CategoryId = request.CategoryId;
            medicine.Description = request.Description;
            medicine.Price = request.Price;

            var updatedMedicine = await _medicineRepository.UpdateAsync(medicine);
            var result = _mapper.Map<UpdatedMedicineDto>(updatedMedicine);
            return result;
        }
    }
}