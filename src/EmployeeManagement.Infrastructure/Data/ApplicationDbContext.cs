using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Domain.Entities;


namespace EmployeeManagement.Infrastructure.Data
{
    /// <summary>
    /// Application database context.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {               
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Initial Catalog=EmployeesDB; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}