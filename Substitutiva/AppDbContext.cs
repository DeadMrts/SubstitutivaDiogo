using Microsoft.EntityFrameworkCore;

namespace Substitutiva.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<IMCdados> IMCs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=LarissaMartins.db");
        }
    }
}
