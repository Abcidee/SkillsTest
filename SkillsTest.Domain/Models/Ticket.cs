using SkillsTest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsTest.Domain.Models
{
    public class Ticket : BaseModel
    {        
        [Required, MinLength(2), MaxLength(100)]
        public string Title { get; set; }

        [Required, MinLength(2)]
        public string Description { get; set; }
        
        public Priority Priority { get; set; }

        public Status Status { get; set; }
    }
}
