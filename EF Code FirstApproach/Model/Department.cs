using System.ComponentModel.DataAnnotations;

namespace Employee_management_system.Model
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? DepartmentName { get; set; }
    }
}
