using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Features.Sales.Commands.CreateSale;
using Pharmacy.Application.Features.Sales.Commands.DeleteSale;
using Pharmacy.Application.Features.Sales.Commands.UpdateSale;
using Pharmacy.Application.Features.Sales.Queries.GetSaleById;
using Pharmacy.Application.Features.Sales.Queries.GetSaleList;

namespace Pharmacy.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest request)
    {
        var query = new GetSaleListQuery { PageRequest = request };
        var result = await Mediator!.Send(query);
        return Ok(result);
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromQuery] GetSaleByIdQuery query)
    {
        var result = await Mediator!.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSaleCommand command)
    {
        var result = await Mediator!.Send(command);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSaleCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeleteSaleCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }
}