using AutoMapper;
using Core.Persistence.Paging;
using Pharmacy.Application.Features.Purchases.Command.CreatePurchase;
using Pharmacy.Application.Features.Purchases.Command.DeletePurchase;
using Pharmacy.Application.Features.Purchases.Command.UpdatePurchase;
using Pharmacy.Application.Features.Purchases.Dto;
using Pharmacy.Application.Features.Purchases.Models;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Purchases.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Purchase, CreatePurchaseCommand>().ReverseMap();
        CreateMap<Purchase, CreatedPurchaseDto>().ReverseMap();
        CreateMap<Purchase, UpdatePurchaseCommand>().ReverseMap();
        CreateMap<Purchase, UpdatedPurchaseDto>().ReverseMap();
        CreateMap<Purchase, DeletePurchaseCommand>().ReverseMap();
        CreateMap<Purchase, DeletedPurchaseDto>().ReverseMap();
        CreateMap<Purchase, PurchaseDto>().ReverseMap();
        CreateMap<Purchase, PurchaseListDto>().ReverseMap();
        CreateMap<Sale, PurchaseSaleDto>().ReverseMap();
        CreateMap<IPaginate<Purchase>, PurchaseListModel>();
    }
}