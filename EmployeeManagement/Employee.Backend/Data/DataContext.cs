using EmployeeManagement.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Employee>().Property(e => e.Salary).HasPrecision(18, 2);
    }
}