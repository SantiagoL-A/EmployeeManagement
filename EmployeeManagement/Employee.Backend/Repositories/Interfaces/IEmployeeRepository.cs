using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Backend.Repositories.Interfaces;
using EmployeeManagement.Shared.Entities;

namespace EmployeeManagement.Backend.Repositories.Interfaces;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<List<Employee>> GetEmployeesNameByTextAsync(string searchText);

    Task<List<Employee>> GetEmployeesLastNameByTextAsync(string searchText);

    Task<List<Employee>> GetEmployeesFullNameByTextAsync(string searchText);
}