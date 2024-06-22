using CidadeLimpa.Models;
using Microsoft.EntityFrameworkCore;


namespace CidadeLimpa.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<LixeiraModel> Lixeiras { get; set; }
        public DbSet<LixeiraParaColetaModel> LixeirasParaColeta { get; set; }
        public DbSet<PontoColetaModel> PontosColeta { get; set; }
        
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


            modelBuilder.Entity<LixeiraParaColetaModel>(entity => {
                entity.ToTable("LixeiraParaColeta");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.DataSolicitacao).IsRequired().HasColumnType("date");
                entity.Property(p => p.DataLimite).IsRequired().HasColumnType("date");
                entity.Property(p => p.Ativo).IsRequired().HasColumnType("number(1)");
                entity.HasOne(e => e.Lixeira).WithMany().HasForeignKey(e => e.IdLixeira).IsRequired();
            });


            modelBuilder.Entity<PontoColetaModel>(entity =>
            {
                entity.ToTable("PontoColeta");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Ponto).IsRequired().HasMaxLength(40);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
