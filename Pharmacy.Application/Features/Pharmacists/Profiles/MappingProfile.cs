using AutoMapper;
using Core.Persistence.Paging;
using Pharmacy.Application.Features.Pharmacists.Commands.CreatePharmacist;
using Pharmacy.Application.Features.Pharmacists.Commands.DeletePharmacist;
using Pharmacy.Application.Features.Pharmacists.Commands.UpdatePharmacist;
using Pharmacy.Application.Features.Pharmacists.Dto;
using Pharmacy.Application.Features.Pharmacists.Models;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Pharmacists.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Pharmacist, CreatePharmacistCommand>().ReverseMap();
        CreateMap<Pharmacist, CreatedPharmacistDto>().ReverseMap();
        CreateMap<Pharmacist, UpdatePharmacistCommand>().ReverseMap();
        CreateMap<Pharmacist, UpdatedPharmacistDto>().ReverseMap();
        CreateMap<Pharmacist, DeletePharmacistCommand>().ReverseMap();
        CreateMap<Pharmacist, DeletedPharmacistDto>().ReverseMap();
        CreateMap<Pharmacist, PharmacistDto>().ReverseMap();
        CreateMap<Pharmacist, PharmacistListDto>().ReverseMap();
        CreateMap<Pharmacist, PharmacistSaleDto>().ReverseMap();
        CreateMap<IPaginate<Pharmacist>, PharmacistListModel>().ReverseMap();
    }
}