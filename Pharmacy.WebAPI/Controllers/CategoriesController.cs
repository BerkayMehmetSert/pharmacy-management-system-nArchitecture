using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Features.Categories.Commands.CreateCategory;
using Pharmacy.Application.Features.Categories.Commands.DeleteCategory;
using Pharmacy.Application.Features.Categories.Commands.UpdateCategory;
using Pharmacy.Application.Features.Categories.Queries.GetCategoryById;
using Pharmacy.Application.Features.Categories.Queries.GetListCategory;

namespace Pharmacy.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
    {
        var query = new GetListCategoryQuery { PageRequest = pageRequest };
        var result = await Mediator!.Send(query);
        return Ok(result);
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromQuery] GetCategoryByIdQuery query)
    {
        var result = await Mediator!.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
    {
        var result = await Mediator!.Send(command);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }
}