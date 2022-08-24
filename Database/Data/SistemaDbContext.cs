using Database.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaRH.Database.Entity;

namespace SistemaRH.Database.Data
{
    public class SistemaDbContext : IdentityDbContext
    {
        public SistemaDbContext(DbContextOptions<SistemaDbContext> options)
            : base(options)
        {
        }

        public SistemaDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (optionsBuilder.IsConfigured)
            //{
                //TODO: tirar connection string daqui
                optionsBuilder.UseSqlServer("Data Source=CTNDELL3CHX783\\SQLEXPRESS;Initial Catalog=sistemarh;Integrated Security=True",
                    builder => builder.EnableRetryOnFailure());
            //}
        }

        public DbSet<AtividadeDP> AtividadeDP { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
