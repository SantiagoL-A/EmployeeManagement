using EmployeeManagement.Shared.Responses;
using NPOI.SS.Formula.Functions;

namespace EmployeeManagement.Backend.UnitsOfWorks.Interfaces
{
    public interface IGenericUnitOfWorks<T> where T : class
    {
        Task<ActionResponse<T>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<T>>> GetAsync();

        Task<ActionResponse<IEnumerable<T>>> SerchAsync(string text);

        Task<ActionResponse<T>> AddAsync(T entity);

        Task<ActionResponse<T>> DeleteAsync(int id);

        Task<ActionResponse<T>> UpdateAsync(T entity);
    }
}