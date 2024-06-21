using CidadeLimpa.Models;
using Microsoft.EntityFrameworkCore;


namespace CidadeLimpa.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<LixeiraModel> Lixeiras { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LixeiraModel>(entity => {
                entity.ToTable("Lixeira");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Localizacao).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Capacidade).IsRequired();
                entity.Property(p => p.Ocupacao).IsRequired().HasPrecision(3, 2);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
