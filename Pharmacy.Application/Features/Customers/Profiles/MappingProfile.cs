using AutoMapper;
using Core.Persistence.Paging;
using Pharmacy.Application.Features.Categories.Commands.DeleteCategory;
using Pharmacy.Application.Features.Customers.Commands.CreateCustomer;
using Pharmacy.Application.Features.Customers.Commands.UpdateCustomer;
using Pharmacy.Application.Features.Customers.Dto;
using Pharmacy.Application.Features.Customers.Models;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Customers.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
        CreateMap<Customer, CreatedCustomerDto>().ReverseMap();
        CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
        CreateMap<Customer, UpdatedCustomerDto>().ReverseMap();
        CreateMap<Customer, DeleteCategoryCommand>().ReverseMap();
        CreateMap<Customer, DeletedCustomerDto>().ReverseMap();
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Customer, CustomerListDto>().ReverseMap();
        CreateMap<Sale, CustomerSaleDto>().ReverseMap();
        CreateMap<Purchase, CustomerPurchaseDto>().ReverseMap();
        CreateMap<Report, CustomerReportDto>().ReverseMap();
        CreateMap<IPaginate<Customer>, CustomerModelList>();
    }
}