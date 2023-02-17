using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Features.Purchases.Command.CreatePurchase;
using Pharmacy.Application.Features.Purchases.Command.DeletePurchase;
using Pharmacy.Application.Features.Purchases.Command.UpdatePurchase;
using Pharmacy.Application.Features.Purchases.Queries.GetPurchaseById;
using Pharmacy.Application.Features.Purchases.Queries.GetPurchaseList;

namespace Pharmacy.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PurchasesController : BaseController
{
    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromQuery] GetPurchaseByIdQuery query)
    {
        var result = await Mediator!.Send(query);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
    {
        var query = new GetPurchaseListQuery { PageRequest = pageRequest };
        var result = await Mediator!.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePurchaseCommand command)
    {
        var result = await Mediator!.Send(command);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePurchaseCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeletePurchaseCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }
}