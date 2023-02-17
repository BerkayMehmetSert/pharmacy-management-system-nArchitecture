using AutoMapper;
using Core.Persistence.Paging;
using Pharmacy.Application.Features.Medicines.Commands.CreateMedicine;
using Pharmacy.Application.Features.Medicines.Commands.DeleteMedicine;
using Pharmacy.Application.Features.Medicines.Commands.UpdateMedicine;
using Pharmacy.Application.Features.Medicines.Dto;
using Pharmacy.Application.Features.Medicines.Models;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Medicines.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Medicine, CreateMedicineCommand>().ReverseMap();
        CreateMap<Medicine, CreatedMedicineDto>().ReverseMap();
        CreateMap<Medicine, UpdateMedicineCommand>().ReverseMap();
        CreateMap<Medicine, UpdatedMedicineDto>().ReverseMap();
        CreateMap<Medicine, DeleteMedicineCommand>().ReverseMap();
        CreateMap<Medicine, DeletedMedicineDto>().ReverseMap();
        CreateMap<Medicine, MedicineDto>().ReverseMap();
        CreateMap<Medicine, MedicineListDto>().ReverseMap(); 
        CreateMap<Purchase, MedicinePurchaseDto>();
        CreateMap<Sale, MedicineSaleDto>().ReverseMap(); 
        CreateMap<IPaginate<Medicine>, MedicineListModel>().ReverseMap();
    }
}