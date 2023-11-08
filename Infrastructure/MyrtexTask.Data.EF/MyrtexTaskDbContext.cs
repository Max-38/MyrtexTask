using Microsoft.EntityFrameworkCore;
using MyrtexTask.Data.EF.EntityTypeConfigurations;
using MyrtexTask.Domain;

namespace MyrtexTask.Data.EF
{
    public class MyrtexTaskDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public MyrtexTaskDbContext(DbContextOptions<MyrtexTaskDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
