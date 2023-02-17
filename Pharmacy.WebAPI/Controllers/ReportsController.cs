using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Features.Reports.Commands.CreateReport;
using Pharmacy.Application.Features.Reports.Commands.DeleteReport;
using Pharmacy.Application.Features.Reports.Commands.UpdateReport;
using Pharmacy.Application.Features.Reports.Queries.GetReportById;
using Pharmacy.Application.Features.Reports.Queries.GetReportList;

namespace Pharmacy.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
    {
        var query = new GetReportListQuery { PageRequest = pageRequest };
        var result = await Mediator!.Send(query);
        return Ok(result);
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromQuery] GetReportByIdQuery query)
    {
        var result = await Mediator!.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReportCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateReportCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeleteReportCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }
}