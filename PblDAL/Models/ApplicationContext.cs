using Microsoft.EntityFrameworkCore;

namespace PblDAL.Models
{ 
    public class ApplicationContext : DbContext
    {
        public DbSet<Controller> Controllers { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Light> Lights { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=pbl;user id=postgres;password=p7wbBOLE;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Light>()
            //.HasAlternateKey(x => new { x.ControllerId, x.Num, x.Address });
        }
    }
}
