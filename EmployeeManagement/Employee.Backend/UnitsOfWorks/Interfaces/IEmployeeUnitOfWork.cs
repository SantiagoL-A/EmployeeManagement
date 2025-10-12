using EmployeeManagement.Shared.Entities;
using EmployeeManagement.Shared.Responses;
using NPOI.SS.Formula.Functions;
using Orders.shared.DTOs;

namespace EmployeeManagement.Backend.UnitsOfWorks.Interfaces;

public interface IEmployeeUnitOfWork
{
    Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);

    Task<List<Employee>> GetEmployeesNameByTextAsync(string searchText);

    Task<List<Employee>> GetEmployeesLastNameByTextAsync(string searchText);

    Task<List<Employee>> GetEmployeesFullNameByTextAsync(string searchText);
}