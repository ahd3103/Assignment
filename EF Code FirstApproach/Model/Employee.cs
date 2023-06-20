using System.ComponentModel.DataAnnotations;

namespace EF_Code_FirstApproach.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string FirstName { get; set; } = null!;
        [Required]

        public string LastName { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public int ContactNo { get; set; }

        [Required]
        public string Gender { get; set; } = null!;

    }
}
