using Microsoft.AspNetCore.Mvc;
using MvcDemo.Models.RegisterUtilities;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse" ,controller: "Account")]
        [ValidateEmailDomain(AlloweDomain: "gmail.com")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage ="Password and Confirmation Password do not match")]
        public string ConfirmPassword { get; set;}
    }
}

namespace MvcDemo.Models.RegisterUtilities
{
    public class ValidateEmailDomainAttribute : ValidationAttribute
    {
        private readonly string _alloweDomain;
        public ValidateEmailDomainAttribute(string AlloweDomain)
        {
            this._alloweDomain = AlloweDomain;
        }

        public override bool IsValid(object value)
        {
            return value.ToString().Split('@')[1].ToLower() == _alloweDomain;
        }
    }
}