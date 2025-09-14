using EmployeeManagement.Backend.Repositories.Interfaces;

using EmployeeManagement.Backend.UnitsOfWorks.Interfaces;
using EmployeeManagement.Shared.Responses;

namespace EmployeeManagement.Backend.UnitsOfWorks.Implementations;

public class GenericUnitOfWork<T> : IGenericUnitOfWorks<T> where T : class
{
    private readonly IGenericRepository<T> _repository;

    public GenericUnitOfWork(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    public virtual async Task<ActionResponse<T>> AddAsync(T entity) => await _repository.AddAsync(entity);

    public virtual async Task<ActionResponse<T>> DeleteAsync(int id) => await _repository.DeleteAsync(id);

    public virtual async Task<ActionResponse<T>> GetAsync(int id) => await _repository.GetAsync(id);

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync() => await _repository.GetAsync();

    public virtual async Task<ActionResponse<T>> UpdateAsync(T entity) => await _repository.UpdateAsync(entity);
}