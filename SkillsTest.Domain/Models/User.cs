using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsTest.Domain.Models
{
    public class User : BaseModel
    {
        [Required, MinLength(2), MaxLength(50)]
        public string Firstname { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string Lastname { get; set; }

        private string emailAddress;
        [Required, MinLength(5), MaxLength(50), EmailAddress]
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value.Trim().ToLower(); }
        }
        
        public string Password { get; set; }

        public string ClearTextPassword { set { Password = !string.IsNullOrEmpty(value) ? BCrypt.Net.BCrypt.HashPassword(value) : null; } }

        public string Fullname
        {
            get
            {
                return string.Format("{0} {1}", this.Firstname, this.Lastname);
            }
        }
    }
}
