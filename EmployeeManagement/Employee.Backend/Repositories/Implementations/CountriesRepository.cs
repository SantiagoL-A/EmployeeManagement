using EmployeeManagement.Backend.Data;
using EmployeeManagement.Backend.Helpers;
using EmployeeManagement.Backend.Repositories.Interfaces;
using EmployeeManagement.Shared.Entities;
using EmployeeManagement.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using Orders.shared.DTOs;

namespace EmployeeManagement.Backend.Repositories.Implementations;

public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
{
    private readonly DataContext _context;

    public CountriesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Country>> GetComboAsync()
    {
        return await _context.Countries
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.Countries
            .Include(c => c.States)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
        }

        return new ActionResponse<IEnumerable<Country>>
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
        var queryable = _context.Countries.AsQueryable();

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

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync()
    {
        var countries = await _context.Countries
            .Include(x => x.States)
            .ToListAsync();
        return new ActionResponse<IEnumerable<Country>>
        {
            WasSucces = true,
            Result = countries
        };
    }

    public override async Task<ActionResponse<Country>> GetAsync(int id)
    {
        var country = await _context.Countries
            .Include(x => x.States!)
            .ThenInclude(x => x.Cities)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (country == null)
        {
            return new ActionResponse<Country>
            {
                Message = "Registro no encontrado"
            };
        }
        return new ActionResponse<Country>
        {
            WasSucces = true,
            Result = country
        };
    }
}