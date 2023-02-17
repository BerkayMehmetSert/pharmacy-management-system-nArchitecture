using Core.Application.Dtos;

namespace Pharmacy.Application.Features.Customers.Dto;

public class BaseCustomerDto : IDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public string ContactAddress { get; set; }
    public string Email { get; set; }
}