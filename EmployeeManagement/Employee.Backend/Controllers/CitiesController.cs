using EmployeeManagement.Backend.UnitsOfWorks.Implementations;
using EmployeeManagement.Backend.UnitsOfWorks.Interfaces;
using EmployeeManagement.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orders.shared.DTOs;

namespace EmployeeManagement.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : GenericController<City>
{
    private readonly ICitiesUnitOfWork _citiesUnitOfWork;

    public CitiesController(IGenericUnitOfWorks<City> unitOfWork, ICitiesUnitOfWork citiesUnitOfWork) : base(unitOfWork)
    {
        _citiesUnitOfWork = citiesUnitOfWork;
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
    {
        var response = await _citiesUnitOfWork.GetAsync(pagination);
        if (response.WasSucces)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("totalRecords")]
    public override async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
    {
        var action = await _citiesUnitOfWork.GetTotalRecordsAsync(pagination);
        if (action.WasSucces)
        {
            return Ok(action.Result);
        }
        return BadRequest();
    }
}