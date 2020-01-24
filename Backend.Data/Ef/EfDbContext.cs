using Backend.Data.Ef.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Ef
{
    public class EfDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=Backend;trusted_connection=true;");
        }
    }
}
