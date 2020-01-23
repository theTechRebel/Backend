using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Ef
{
    public class EfDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=Backend;trusted_connection=true;");
        }
    }
}
