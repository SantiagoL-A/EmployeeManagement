using EmployeeManagement.Shared.Entities;
using EmployeeManagement.Backend.UnitsOfWorks.Interfaces;
using EmployeeManagement.Backend.Repositories.Interfaces;
using EmployeeManagement.Shared.Responses;
using Orders.shared.DTOs;
using NPOI.SS.Formula.Functions;

namespace EmployeeManagement.Backend.UnitsOfWorks.Implementations;

public class EmployeeUnitOfWork : GenericUnitOfWork<Employee>, IEmployeeUnitOfWork

{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeUnitOfWork(IGenericRepository<Employee> repository, IEmployeeRepository employeeRepository) : base(repository)
    {
        _employeeRepository = employeeRepository;
    }

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _employeeRepository.GetTotalRecordsAsync(pagination);

    public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination) => await _employeeRepository.GetAsync(pagination);

    public async Task<List<Employee>> GetEmployeesFullNameByTextAsync(string searchText) => await _employeeRepository.GetEmployeesFullNameByTextAsync(searchText);

    public async Task<List<Employee>> GetEmployeesLastNameByTextAsync(string searchText) => await _employeeRepository.GetEmployeesLastNameByTextAsync(searchText);

    public async Task<List<Employee>> GetEmployeesNameByTextAsync(string searchText) => await _employeeRepository.GetEmployeesNameByTextAsync(searchText);
}