using EmployeeManagement.Shared.Entities;
using EmployeeManagement.Backend.UnitsOfWorks.Interfaces;
using EmployeeManagement.Backend.Repositories.Interfaces;

namespace EmployeeManagement.Backend.UnitsOfWorks.Implementations;

public class EmployeeUnitOfWork : GenericUnitOfWork<Employee>, IEmployeeUnitOfWork

{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeUnitOfWork(IGenericRepository<Employee> repository, IEmployeeRepository employeeRepository) : base(repository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<List<Employee>> GetEmployeesFullNameByTextAsync(string searchText) => await _employeeRepository.GetEmployeesFullNameByTextAsync(searchText);

    public async Task<List<Employee>> GetEmployeesLastNameByTextAsync(string searchText) => await _employeeRepository.GetEmployeesLastNameByTextAsync(searchText);

    public async Task<List<Employee>> GetEmployeesNameByTextAsync(string searchText) => await _employeeRepository.GetEmployeesNameByTextAsync(searchText);
}