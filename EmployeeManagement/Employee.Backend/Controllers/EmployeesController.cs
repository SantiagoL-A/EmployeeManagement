using EmployeeManagement.Backend.Repositories.Interfaces;
using EmployeeManagement.Backend.UnitsOfWorks.Interfaces;
using EmployeeManagement.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Orders.shared.DTOs;

namespace EmployeeManagement.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : GenericController<Employee>
{
    private readonly IEmployeeUnitOfWork _employeeUnitOfWork;

    public EmployeesController(IGenericUnitOfWorks<Employee> unitofwork, IEmployeeUnitOfWork employeeUnitOfWork) : base(unitofwork)
    {
        _employeeUnitOfWork = employeeUnitOfWork;
    }

    [HttpGet("searchName")]
    public async Task<ActionResult<List<Employee>>> SearchByName([FromQuery] string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return BadRequest("El texto no puede estar vacío");

        var employees = await _employeeUnitOfWork.GetEmployeesNameByTextAsync(text);
        if (employees.Count == 0)
            return NotFound("No se encontraron empleados");

        return Ok(employees);
    }

    [HttpGet("searchLastName")]
    public async Task<ActionResult<List<Employee>>> SearchByLastName([FromQuery] string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return BadRequest("El texto no puede estar vacío");

        var employees = await _employeeUnitOfWork.GetEmployeesLastNameByTextAsync(text);
        if (employees.Count == 0)
            return NotFound("No se encontraron empleados");

        return Ok(employees);
    }

    [HttpGet("searchFullName")]
    public async Task<ActionResult<List<Employee>>> SearchByFullName([FromQuery] string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return BadRequest("El texto no puede estar vacío");

        var employees = await _employeeUnitOfWork.GetEmployeesFullNameByTextAsync(text);
        if (employees.Count == 0)
            return NotFound("No se encontraron empleados");

        return Ok(employees);
    }

    [HttpGet("totalRecords")]
    public override async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
    {
        var action = await _employeeUnitOfWork.GetTotalRecordsAsync(pagination);
        if (action.WasSucces)
        {
            return Ok(action.Result);
        }
        return BadRequest();
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
    {
        var action = await _employeeUnitOfWork.GetAsync(pagination);
        if (action.WasSucces)
        {
            return Ok(action.Result);
        }
        return BadRequest();
    }
}