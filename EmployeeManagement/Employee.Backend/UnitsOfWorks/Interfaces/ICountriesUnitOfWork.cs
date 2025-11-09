using EmployeeManagement.Shared.Entities;
using EmployeeManagement.Shared.Responses;
using Orders.shared.DTOs;

namespace EmployeeManagement.Backend.UnitsOfWorks.Interfaces;

public interface ICountriesUnitOfWork
{
    Task<IEnumerable<Country>> GetComboAsync();

    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);

    Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<Country>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Country>>> GetAsync();
}