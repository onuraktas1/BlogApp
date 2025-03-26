using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BlogApiDb;Trusted_Connection=True;TrustServerCertificate=true");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
