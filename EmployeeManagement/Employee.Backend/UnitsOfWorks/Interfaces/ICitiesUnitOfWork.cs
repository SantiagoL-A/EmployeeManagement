using EmployeeManagement.Shared.Entities;
using EmployeeManagement.Shared.Responses;
using Orders.shared.DTOs;

namespace EmployeeManagement.Backend.UnitsOfWorks.Interfaces;

public interface ICitiesUnitOfWork
{
    Task<IEnumerable<City>> GetComboAsync(int stateId);

    Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
}