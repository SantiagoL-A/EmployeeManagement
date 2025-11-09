using EmployeeManagement.Backend.UnitsOfWorks.Implementations;
using EmployeeManagement.Backend.UnitsOfWorks.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orders.shared.DTOs;

namespace EmployeeManagement.Backend.Controllers;

[ApiController]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
public class StatesController : GenericController<State>
{
    private readonly IStatesUnitOfWork _statesUnitOfWork;

    public StatesController(IGenericUnitOfWorks<State> unitOfWork, IStatesUnitOfWork statesUnitOfWork) : base(unitOfWork)
    {
        _statesUnitOfWork = statesUnitOfWork;
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
    {
        var response = await _statesUnitOfWork.GetAsync(pagination);
        if (response.WasSucces)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("totalRecords")]
    public override async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
    {
        var action = await _statesUnitOfWork.GetTotalRecordsAsync(pagination);
        if (action.WasSucces)
        {
            return Ok(action.Result);
        }
        return BadRequest();
    }

    [HttpGet]
    public override async Task<IActionResult> GetAsync()
    {
        var response = await _statesUnitOfWork.GetAsync();
        if (response.WasSucces)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var response = await _statesUnitOfWork.GetAsync(id);
        if (response.WasSucces)
        {
            return Ok(response.Result);
        }
        return NotFound(response.Message);
    }
}