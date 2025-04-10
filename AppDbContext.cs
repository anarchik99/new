using Microsoft.EntityFrameworkCore;

namespace Lecture5_Gr1
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("CarsDB");    
        }
    }
}
