using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Required*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required*")]
        public string FullName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Required*")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required*")]
        public string Mobile { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Required*")]
        [Display(Name = "Department")]
        public int DepId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string Department { get; set; }
    }
}
