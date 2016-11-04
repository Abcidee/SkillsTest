using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillsTest.Domain
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            this.CreatedAt = DateTimeOffset.UtcNow;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
