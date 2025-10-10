using Orders.shared.DTOs;

namespace EmployeeManagement.Backend.Helpers;

public static class QuaryableExtensions
{
    public static IQueryable<T> paginate<T>(this IQueryable<T> queryable, PaginationDTO pagination)
    {
        return queryable.Skip((pagination.Page - 1) * pagination.RecordsNumber).Take(pagination.RecordsNumber);
    }
}