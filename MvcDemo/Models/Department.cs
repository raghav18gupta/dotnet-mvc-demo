using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required*")]
        public string Name { get; set; }
    }
}
