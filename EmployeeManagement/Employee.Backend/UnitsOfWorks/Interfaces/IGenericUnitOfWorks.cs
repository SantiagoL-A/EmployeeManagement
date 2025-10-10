using EmployeeManagement.Shared.Responses;
using Orders.shared.DTOs;

namespace EmployeeManagement.Backend.UnitsOfWorks.Interfaces
{
    public interface IGenericUnitOfWorks<T> where T : class
    {
        Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);

        Task<ActionResponse<T>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<T>>> GetAsync();

        Task<ActionResponse<T>> AddAsync(T entity);

        Task<ActionResponse<T>> DeleteAsync(int id);

        Task<ActionResponse<T>> UpdateAsync(T entity);
    }
}