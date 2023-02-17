using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Features.Medicines.Models;
using Pharmacy.Application.Features.Medicines.Rules;
using Pharmacy.Application.Services.Repositories;

namespace Pharmacy.Application.Features.Medicines.Queries.GetListMedicine;

public class GetListMedicineQuery : IRequest<MedicineListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListMedicineQueryHandler : IRequestHandler<GetListMedicineQuery, MedicineListModel>
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IMapper _mapper;
        private readonly MedicineBusinessRules _rules;

        public GetListMedicineQueryHandler(IMedicineRepository medicineRepository, IMapper mapper,
            MedicineBusinessRules rules)
        {
            _medicineRepository = medicineRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<MedicineListModel> Handle(GetListMedicineQuery request, CancellationToken cancellationToken)
        {
            var medicines = await _medicineRepository.GetListAsync(
                include: x =>
                    x.Include(y => y.Sales)
                    .Include(y => y.Purchases),
                size: request.PageRequest.PageSize,
                index: request.PageRequest.Page
            );

            _rules.CheckIfMedicineListIsEmpty(medicines);

            var result = _mapper.Map<MedicineListModel>(medicines);
            return result;
        }
    }
}