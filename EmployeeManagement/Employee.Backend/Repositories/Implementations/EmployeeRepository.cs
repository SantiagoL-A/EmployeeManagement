using System.Linq;
using EmployeeManagement.Backend.Data;
using EmployeeManagement.Backend.Helpers;
using EmployeeManagement.Backend.Repositories.Interfaces;

using EmployeeManagement.Shared.Entities;
using EmployeeManagement.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using Orders.shared.DTOs;

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

    public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.Employees
            .AsQueryable();
        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            var filter = pagination.Filter.ToLower();

            queryable = queryable.Where(x =>
                x.FirstName.ToLower().Contains(filter) ||
                x.LastName.ToLower().Contains(filter));
        }

        return new ActionResponse<IEnumerable<Employee>>
        {
            WasSucces = true,
            Result = await queryable
                .OrderBy(c => c.FirstName)
                .paginate(pagination)
                .ToListAsync()
        };
    }

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        var queryable = _context.Employees.AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            var filter = pagination.Filter.ToLower();

            queryable = queryable.Where(x =>
                x.FirstName.ToLower().Contains(filter) ||
                x.LastName.ToLower().Contains(filter));
        }

        double count = await queryable.CountAsync();
        return new ActionResponse<int>
        {
            WasSucces = true,
            Result = (int)count
        };
    }
}