using System.ComponentModel.DataAnnotations;

namespace Employee_management_system.Model
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string? Name { get; set; }

        [Range(21, 100)]
        public int Age { get; set; }

        public Decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}
