using Microsoft.EntityFrameworkCore;

namespace TestASPApi.Models
{
    public class EntityContext : DbContext
    {
        public DbSet<Employee>? Employees {  get; set; }
        public DbSet<Department>? Departments { get; set; }

        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
