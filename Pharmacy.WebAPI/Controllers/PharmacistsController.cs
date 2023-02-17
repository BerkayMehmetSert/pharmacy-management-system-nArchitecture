using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Features.Pharmacists.Commands.CreatePharmacist;
using Pharmacy.Application.Features.Pharmacists.Commands.DeletePharmacist;
using Pharmacy.Application.Features.Pharmacists.Commands.UpdatePharmacist;
using Pharmacy.Application.Features.Pharmacists.Queries.GetPharmacistById;
using Pharmacy.Application.Features.Pharmacists.Queries.GetPharmacistList;

namespace Pharmacy.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PharmacistsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest request)
    {
        var query = new GetPharmacistListQuery { PageRequest = request };
        var result = await Mediator!.Send(query);
        return Ok(result);
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromQuery] GetPharmacistByIdQuery query)
    {
        var result = await Mediator!.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePharmacistCommand command)
    {
        var result = await Mediator!.Send(command);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePharmacistCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeletePharmacistCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }
}