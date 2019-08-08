using Microsoft.EntityFrameworkCore;

namespace ProjectName.Models
{
    public class ProjectNameContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public DbSet<Class2>  Class2Table { get; set; }
        public ProjectNameContext(DbContextOptions options) : base(options) { }
    }
}