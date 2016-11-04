namespace SkillsTest.Domain
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext()
            : base("name=DefaultDbContext")
        {
        }
        
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}