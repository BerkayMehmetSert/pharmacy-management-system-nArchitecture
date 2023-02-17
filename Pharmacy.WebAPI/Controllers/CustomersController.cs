using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Features.Customers.Commands.CreateCustomer;
using Pharmacy.Application.Features.Customers.Commands.DeleteCustomer;
using Pharmacy.Application.Features.Customers.Commands.UpdateCustomer;
using Pharmacy.Application.Features.Customers.Queries;
using Pharmacy.Application.Features.Customers.Queries.GetCustomerById;
using Pharmacy.Application.Features.Customers.Queries.GetListCustomerQuery;

namespace Pharmacy.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
    {
        var query = new GetListCustomerQuery() { PageRequest = pageRequest };
        var result = await Mediator!.Send(query);
        return Ok(result);
    }
    
    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromQuery] GetCustomerByIdQuery query)
    {
        var result = await Mediator!.Send(query);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
    {
        var result = await Mediator!.Send(command);
        return Created("", result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteCustomer([FromBody] DeleteCustomerCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }
}