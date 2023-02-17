using AutoMapper;
using Core.Persistence.Paging;
using Pharmacy.Application.Features.Sales.Commands.CreateSale;
using Pharmacy.Application.Features.Sales.Commands.DeleteSale;
using Pharmacy.Application.Features.Sales.Commands.UpdateSale;
using Pharmacy.Application.Features.Sales.Dto;
using Pharmacy.Application.Features.Sales.Models;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Sales.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Sale, CreateSaleCommand>().ReverseMap();
        CreateMap<Sale, CreatedSaleDto>().ReverseMap();
        CreateMap<Sale, UpdateSaleCommand>().ReverseMap();
        CreateMap<Sale, UpdatedSaleDto>().ReverseMap();
        CreateMap<Sale, DeleteSaleCommand>().ReverseMap();
        CreateMap<Sale, DeletedSaleDto>().ReverseMap();
        CreateMap<Sale, SaleDto>().ReverseMap();
        CreateMap<Sale, SaleListDto>().ReverseMap();
        CreateMap<IPaginate<Sale>, SaleListModel>().ReverseMap();
    }
}