using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
