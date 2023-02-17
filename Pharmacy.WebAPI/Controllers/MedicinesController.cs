using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Features.Medicines.Commands.CreateMedicine;
using Pharmacy.Application.Features.Medicines.Commands.DeleteMedicine;
using Pharmacy.Application.Features.Medicines.Commands.UpdateMedicine;
using Pharmacy.Application.Features.Medicines.Queries.GetListMedicine;
using Pharmacy.Application.Features.Medicines.Queries.GetMedicineById;

namespace Pharmacy.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicinesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest request)
    {
        var query = new GetListMedicineQuery { PageRequest = request };
        var result = await Mediator!.Send(query);
        return Ok(result);
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromQuery] GetMedicineByIdQuery query)
    {
        var result = await Mediator!.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMedicineCommand command)
    {
        var result = await Mediator!.Send(command);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMedicineCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteMedicineCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }
}