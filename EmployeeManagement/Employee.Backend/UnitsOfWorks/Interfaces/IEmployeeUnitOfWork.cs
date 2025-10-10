using EmployeeManagement.Shared.Entities;

namespace EmployeeManagement.Backend.UnitsOfWorks.Interfaces;

public interface IEmployeeUnitOfWork
{
    Task<List<Employee>> GetEmployeesNameByTextAsync(string searchText);

    Task<List<Employee>> GetEmployeesLastNameByTextAsync(string searchText);

    Task<List<Employee>> GetEmployeesFullNameByTextAsync(string searchText);
}