using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkillsTest.Web.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required, MinLength(2), MaxLength(50)]
        public string Firstname { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string Lastname { get; set; }
        
        [Required, MinLength(5), MaxLength(50), EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirmed password did not match with the new password.")]
        public string PasswordConfirmation { get; set; }
    }
}