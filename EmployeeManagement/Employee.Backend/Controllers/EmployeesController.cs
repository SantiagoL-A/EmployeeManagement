using EmployeeManagement.Backend.Repositories.Interfaces;
using EmployeeManagement.Backend.UnitsOfWorks.Interfaces;
using EmployeeManagement.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : GenericController<Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IGenericUnitOfWorks<Employee> unitofwork, IEmployeeRepository employeeRepository) : base(unitofwork)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Employee>>> Search([FromQuery] string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return BadRequest("El texto no puede estar vacío");

            var employees = await _employeeRepository.GetEmployeesByTextAsync(text);
            if (employees.Count == 0)
                return NotFound("No se encontraron empleados");

            return Ok(employees);
        }
    }
}