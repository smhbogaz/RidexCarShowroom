using Microsoft.EntityFrameworkCore;

namespace Ridex_Car_Showroom.DAL
{
    public class AppDbContext:DbContext
    {
        public DbSet<Cars> Cars { get; set; }   
        public DbSet<Members> Members { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

    }
}
