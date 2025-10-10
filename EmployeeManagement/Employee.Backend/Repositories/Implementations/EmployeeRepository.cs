using EmployeeManagement.Backend.Data;

using EmployeeManagement.Backend.Repositories.Interfaces;

using EmployeeManagement.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Backend.Repositories.Implementations;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    private readonly DataContext _context;

    public EmployeeRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetEmployeesNameByTextAsync(string searchText)
    {
        return await _context.Set<Employee>().Where(e => e.FirstName.Contains(searchText)).ToListAsync();
    }

    public async Task<List<Employee>> GetEmployeesLastNameByTextAsync(string searchText)
    {
        return await _context.Set<Employee>().Where(e => e.LastName.Contains(searchText)).ToListAsync();
    }

    public async Task<List<Employee>> GetEmployeesFullNameByTextAsync(string searchText)
    {
        return await _context.Set<Employee>().Where(e => e.LastName.Contains(searchText) || e.FirstName.Contains(searchText)).ToListAsync();
    }
}