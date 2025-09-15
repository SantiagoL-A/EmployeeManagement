using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Shared.Entities;

public class Employee
{
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    [MaxLength(30, ErrorMessage = "El campo {0} No puede tener mas de {1} caracteres")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Apellido")]
    [MaxLength(30, ErrorMessage = "El campo {0} No puede tener mas de {1} caracteres")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public string LastName { get; set; } = null!;

    public bool IsActive { get; set; } = true;

    public DateTime HireDate { get; set; }

    [Required]
    [Range(typeof(decimal), "1000000", "1000000000", ErrorMessage = "El salario minimo es de 1000000")]
    public decimal Salary { get; set; }
}