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
            _context.Employees.AddRange(new List<Employee>
{
            new() { FirstName = "Camilo", LastName = "Zuluaga", IsActive = true, Salary = 2000000, HireDate = new DateTime(2021, 06, 20) },
            new() { FirstName = "Juan", LastName = "Castillo", IsActive = true, Salary = 2500000, HireDate = new DateTime(2022, 04, 22) },
            new() { FirstName = "David", LastName = "Castro", IsActive = true, Salary = 2220000, HireDate = new DateTime(2022, 02, 24) },
            new() { FirstName = "Santiago", LastName = "Lopez", IsActive = true, Salary = 2300000, HireDate = new DateTime(2020, 01, 10) },
            new() { FirstName = "Cristian", LastName = "Zapata", IsActive = true, Salary = 2400000, HireDate = new DateTime(2019, 07, 11) },
            new() { FirstName = "Leonel", LastName = "Benitez", IsActive = true, Salary = 3220000, HireDate = new DateTime(2023, 09, 18) },
            new() { FirstName = "Alvaro", LastName = "Moreno", IsActive = true, Salary = 4220000, HireDate = new DateTime(2018, 11, 01) },
            new() { FirstName = "Sara", LastName = "Rueda", IsActive = true, Salary = 1220000, HireDate = new DateTime(2024, 12, 05) },
            new() { FirstName = "Sofia", LastName = "Sepulveda", IsActive = true, Salary = 1100000, HireDate = new DateTime(2025, 10, 31) },
            new() { FirstName = "Jessica", LastName = "Gonzalez", IsActive = true, Salary = 3300000, HireDate = new DateTime(2022, 02, 25) },
            new() { FirstName = "Camila", LastName = "Jaramillo", IsActive = true, Salary = 2700000, HireDate = new DateTime(2019, 03, 27) },
            new() { FirstName = "David", LastName = "Velasquez", IsActive = true, Salary = 1800000, HireDate = new DateTime(2015, 05, 15) },
            new() { FirstName = "Andres", LastName = "Mendoza", IsActive = true, Salary = 2100000, HireDate = new DateTime(2023, 02, 14) },
            new() { FirstName = "Julian", LastName = "Ramirez", IsActive = true, Salary = 1950000, HireDate = new DateTime(2020, 06, 19) },
            new() { FirstName = "Valentina", LastName = "Cardona", IsActive = true, Salary = 3100000, HireDate = new DateTime(2022, 08, 10) },
            new() { FirstName = "Daniela", LastName = "Martinez", IsActive = true, Salary = 2950000, HireDate = new DateTime(2018, 02, 01) },
            new() { FirstName = "Felipe", LastName = "Suarez", IsActive = true, Salary = 2600000, HireDate = new DateTime(2021, 11, 05) },
            new() { FirstName = "Angela", LastName = "Jimenez", IsActive = true, Salary = 1850000, HireDate = new DateTime(2020, 09, 28) },
            new() { FirstName = "Laura", LastName = "Morales", IsActive = true, Salary = 3550000, HireDate = new DateTime(2022, 05, 12) },
            new() { FirstName = "Carlos", LastName = "Bermudez", IsActive = true, Salary = 3100000, HireDate = new DateTime(2019, 10, 08) },
            new() { FirstName = "Alejandro", LastName = "Ruiz", IsActive = true, Salary = 2700000, HireDate = new DateTime(2023, 07, 19) },
            new() { FirstName = "Daniel", LastName = "Vargas", IsActive = true, Salary = 2250000, HireDate = new DateTime(2017, 12, 14) },
            new() { FirstName = "Isabella", LastName = "Sierra", IsActive = true, Salary = 2600000, HireDate = new DateTime(2021, 03, 21) },
            new() { FirstName = "Tatiana", LastName = "Herrera", IsActive = true, Salary = 1750000, HireDate = new DateTime(2016, 11, 03) },
            new() { FirstName = "Manuel", LastName = "Arboleda", IsActive = true, Salary = 4100000, HireDate = new DateTime(2018, 08, 16) },
            new() { FirstName = "Nicolas", LastName = "Ospina", IsActive = true, Salary = 2450000, HireDate = new DateTime(2019, 01, 20) },
            new() { FirstName = "Tatiana", LastName = "Ramirez", IsActive = true, Salary = 1950000, HireDate = new DateTime(2017, 06, 11) },
            new() { FirstName = "Diana", LastName = "Castaño", IsActive = true, Salary = 2750000, HireDate = new DateTime(2021, 09, 10) },
            new() { FirstName = "Melissa", LastName = "Giraldo", IsActive = true, Salary = 2350000, HireDate = new DateTime(2020, 07, 22) },
            new() { FirstName = "Santiago", LastName = "Gomez", IsActive = true, Salary = 3150000, HireDate = new DateTime(2018, 02, 08) },
            new() { FirstName = "Lucia", LastName = "Salazar", IsActive = true, Salary = 1900000, HireDate = new DateTime(2017, 03, 15) },
            new() { FirstName = "Oscar", LastName = "Loaiza", IsActive = true, Salary = 3300000, HireDate = new DateTime(2019, 10, 05) },
            new() { FirstName = "Juliana", LastName = "Quintero", IsActive = true, Salary = 2000000, HireDate = new DateTime(2021, 01, 30) },
            new() { FirstName = "Mateo", LastName = "Ortiz", IsActive = true, Salary = 2100000, HireDate = new DateTime(2023, 06, 19) },
            new() { FirstName = "Maria", LastName = "Gomez", IsActive = true, Salary = 2500000, HireDate = new DateTime(2020, 02, 14) },
            new() { FirstName = "Lina", LastName = "Cortes", IsActive = true, Salary = 2750000, HireDate = new DateTime(2018, 10, 04) },
            new() { FirstName = "Ricardo", LastName = "Tobon", IsActive = true, Salary = 2200000, HireDate = new DateTime(2022, 09, 02) },
            new() { FirstName = "Sebastian", LastName = "Mejia", IsActive = true, Salary = 2800000, HireDate = new DateTime(2016, 12, 10) },
            new() { FirstName = "Esteban", LastName = "Valencia", IsActive = true, Salary = 2550000, HireDate = new DateTime(2024, 03, 12) },
            new() { FirstName = "Adriana", LastName = "Arias", IsActive = true, Salary = 3450000, HireDate = new DateTime(2019, 04, 07) },
            new() { FirstName = "Andres", LastName = "Hernandez", IsActive = true, Salary = 3200000, HireDate = new DateTime(2020, 09, 18) },
            new() { FirstName = "Catalina", LastName = "Usuga", IsActive = true, Salary = 2350000, HireDate = new DateTime(2022, 10, 22) },
            new() { FirstName = "Felipe", LastName = "Restrepo", IsActive = true, Salary = 2150000, HireDate = new DateTime(2023, 08, 25) },
            new() { FirstName = "Tatiana", LastName = "Lopez", IsActive = true, Salary = 2400000, HireDate = new DateTime(2017, 12, 11) },
            new() { FirstName = "Kevin", LastName = "Rojas", IsActive = true, Salary = 2600000, HireDate = new DateTime(2018, 05, 19) },
            new() { FirstName = "Carlos", LastName = "Perez", IsActive = true, Salary = 2000000, HireDate = new DateTime(2021, 10, 27) },
            new() { FirstName = "Jhon", LastName = "Marin", IsActive = true, Salary = 2450000, HireDate = new DateTime(2023, 01, 14) },
            new() { FirstName = "Eliana", LastName = "Sanchez", IsActive = true, Salary = 2750000, HireDate = new DateTime(2019, 09, 20) },
            new() { FirstName = "Natalia", LastName = "Lozano", IsActive = true, Salary = 2800000, HireDate = new DateTime(2024, 07, 17) },
            new() { FirstName = "Juan", LastName = "Perez", IsActive = true, Salary = 2600000, HireDate = new DateTime(2018, 06, 12) },
            new() { FirstName = "Angela", LastName = "Torres", IsActive = true, Salary = 1950000, HireDate = new DateTime(2020, 08, 22) },
            new() { FirstName = "Andres", LastName = "Silva", IsActive = true, Salary = 2500000, HireDate = new DateTime(2023, 02, 11) },
            new() { FirstName = "Alejandra", LastName = "Garcia", IsActive = true, Salary = 2700000, HireDate = new DateTime(2021, 04, 23) },
        });

        await _context.SaveChangesAsync();
    }
}