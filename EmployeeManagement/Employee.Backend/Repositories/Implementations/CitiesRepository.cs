using EmployeeManagement.Backend.Data;
using EmployeeManagement.Backend.Helpers;
using EmployeeManagement.Backend.Repositories.Interfaces;
using EmployeeManagement.Shared.Entities;
using EmployeeManagement.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using Orders.shared.DTOs;

namespace EmployeeManagement.Backend.Repositories.Implementations;

public class CitiesRepository : GenericRepository<City>, ICitiesRepository
{
    private readonly DataContext _context;

    public CitiesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<City>> GetComboAsync(int stateId)
    {
        return await _context.Cities
            .Where(c => c.StateId == stateId)
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.Cities.AsNoTracking()
            .Where(x => x.State!.Id == pagination.Id)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
        }

        return new ActionResponse<IEnumerable<City>>
        {
            WasSucces = true,
            Result = await queryable
                .OrderBy(x => x.Name)
                .paginate(pagination)
                .ToListAsync()
        };
    }

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        var queryable = _context.Cities.AsNoTracking()
            .Where(x => x.State!.Id == pagination.Id)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
        }

        double count = await queryable.CountAsync();
        return new ActionResponse<int>
        {
            WasSucces = true,
            Result = (int)count
        };
    }
}