using EmployeeManagement.Shared.Entities;

namespace EmployeeManagement.Backend.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckEmployeeAsync();
    }

    private async Task CheckEmployeeAsync()
    {
        if (!_context.Employees.Any())
        {
            _context.Employees.Add(new Employee { FirstName = "Camilo", LastName = "Zuluaga", IsActive = true, Salary = 2000000, HireDate = new DateTime(2021, 06, 20) });
            _context.Employees.Add(new Employee { FirstName = "Juan", LastName = "Castillo", IsActive = true, Salary = 2500000, HireDate = new DateTime(2022, 04, 22) });
            _context.Employees.Add(new Employee { FirstName = "David", LastName = "Castro", IsActive = true, Salary = 2220000, HireDate = new DateTime(2022, 02, 24) });
            _context.Employees.Add(new Employee { FirstName = "Santiago", LastName = "Lopez", IsActive = true, Salary = 2300000, HireDate = new DateTime(2020, 01, 10) });
            _context.Employees.Add(new Employee { FirstName = "Cristian", LastName = "Zapata", IsActive = true, Salary = 2400000, HireDate = new DateTime(2019, 07, 11) });
            _context.Employees.Add(new Employee { FirstName = "Leonel", LastName = "Benitez", IsActive = true, Salary = 3220000, HireDate = new DateTime(2023, 09, 18) });
            _context.Employees.Add(new Employee { FirstName = "Alvaro", LastName = "Moreno", IsActive = true, Salary = 4220000, HireDate = new DateTime(2018, 11, 01) });
            _context.Employees.Add(new Employee { FirstName = "Sara", LastName = "Rueda", IsActive = true, Salary = 1220000, HireDate = new DateTime(2024, 12, 05) });
            _context.Employees.Add(new Employee { FirstName = "Sofia", LastName = "Sepulveda", IsActive = true, Salary = 1100000, HireDate = new DateTime(2025, 10, 31) });
            _context.Employees.Add(new Employee { FirstName = "Jessica", LastName = "Gonzalez", IsActive = true, Salary = 3300000, HireDate = new DateTime(2022, 02, 25) });
            _context.Employees.Add(new Employee { FirstName = "Camila", LastName = "Jaramillo", IsActive = true, Salary = 2700000, HireDate = new DateTime(2019, 03, 27) });
            _context.Employees.Add(new Employee { FirstName = "David", LastName = "Velasquez", IsActive = true, Salary = 1800000, HireDate = new DateTime(2015, 05, 15) });
            await _context.SaveChangesAsync();
        }
    }
}