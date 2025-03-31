using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Server=.;Database=BlogApiDb;Trusted_Connection=True;TrustServerCertificate=true");
            
            optionsBuilder.UseSqlServer("Server=localhost;Database=BlogApiDb;User Id=SA;Password=Onuraktas1234;TrustServerCertificate=True;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
