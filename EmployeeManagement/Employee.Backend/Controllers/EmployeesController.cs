using EmployeeManagement.Backend.UnitsOfWorks.Interfaces;
using EmployeeManagement.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : GenericController<Employee>
{
    public EmployeesController(IGenericUnitOfWorks<Employee> unitOfWork) : base(unitOfWork)
    {
    }
}