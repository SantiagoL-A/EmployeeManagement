using EmployeeManagement.Backend.Data;
using EmployeeManagement.Backend.Helpers;
using EmployeeManagement.Backend.Repositories.Interfaces;
using EmployeeManagement.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using Orders.shared.DTOs;

namespace EmployeeManagement.Backend.Repositories.Implementations;

public class StatesRepository : GenericRepository<State>, IStatesRepository
{
    private readonly DataContext _context;

    public StatesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<State>> GetComboAsync(int countryId)
    {
        return await _context.States
            .Where(s => s.CountryId == countryId)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.States
            .Include(x => x.Cities)
            .Where(x => x.Country!.Id == pagination.Id)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
        }

        return new ActionResponse<IEnumerable<State>>
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
        var queryable = _context.States
            .Where(x => x.Country!.Id == pagination.Id)
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

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync()
    {
        var states = await _context.States
            .Include(s => s.Cities)
            .ToListAsync();
        return new ActionResponse<IEnumerable<State>>
        {
            WasSucces = true,
            Result = states
        };
    }

    public override async Task<ActionResponse<State>> GetAsync(int id)
    {
        var state = await _context.States
             .Include(s => s.Cities)
             .FirstOrDefaultAsync(s => s.Id == id);

        if (state == null)
        {
            return new ActionResponse<State>
            {
                WasSucces = false,
                Message = "Estado no existe"
            };
        }

        return new ActionResponse<State>
        {
            WasSucces = true,
            Result = state
        };
    }
}