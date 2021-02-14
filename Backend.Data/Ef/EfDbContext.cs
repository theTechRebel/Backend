using Backend.Data.Ef.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Ef
{
    public class EfDbContext: DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
