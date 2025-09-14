using EmployeeManagement.Shared.Entities;
using EmployeeManagement.Backend.Repositories.Interfaces;
using EmployeeManagement.Backend.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Backend.Data;

namespace EmployeeManagement.Backend.Repositories.Implementations;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    private readonly DataContext _context;

    public EmployeeRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetEmployeesByTextAsync(string searchText)
    {
        return await _context.Set<Employee>().Where(e => e.FirstName.Contains(searchText) || e.LastName.Contains(searchText)).ToListAsync();
    }
}