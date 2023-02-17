using AutoMapper;
using MediatR;
using Pharmacy.Application.Features.Medicines.Dto;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Medicines.Commands.CreateMedicine;

public class CreateMedicineCommand : IRequest<CreatedMedicineDto>
{
    public int CategoryId { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    
    public class CreateMedicineCommandHandler: IRequestHandler<CreateMedicineCommand, CreatedMedicineDto>
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IMapper _mapper;

        public CreateMedicineCommandHandler(IMedicineRepository medicineRepository, IMapper mapper)
        {
            _medicineRepository = medicineRepository;
            _mapper = mapper;
        }

        public async Task<CreatedMedicineDto> Handle(CreateMedicineCommand request, CancellationToken cancellationToken)
        {
            var requestToEntity = _mapper.Map<Medicine>(request);

            var medicine = await _medicineRepository.AddAsync(requestToEntity);
            var result = _mapper.Map<CreatedMedicineDto>(medicine);
            return result;
        }
    }
}