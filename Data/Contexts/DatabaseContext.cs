using CidadeLimpa.Models;
using Microsoft.EntityFrameworkCore;


namespace CidadeLimpa.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<LixeiraModel> Lixeiras { get; set; }
        public DbSet<LixeiraParaColetaModel> LixeirasParaColeta { get; set; }
        public DbSet<PontoColetaModel> PontosColeta { get; set; }
        public DbSet<RotaModel> Rotas { get; set; }
        public DbSet<CaminhaoModel> Caminhoes { get; set; }
        public DbSet<ColetaModel> Coletas { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
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


            modelBuilder.Entity<RotaModel>(entity =>
            {
                entity.ToTable("Rota");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.HorarioInicio).IsRequired().HasMaxLength(5);
                entity.Property(p => p.HorarioFim).IsRequired().HasMaxLength(5);
            });


            modelBuilder.Entity<PontoColetaModel>(entity =>
            {
                entity.ToTable("PontoColeta");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Ponto).IsRequired().HasMaxLength(40);
                entity.HasOne(p => p.Rota)
                    .WithMany(r => r.ListaPontosColeta)
                    .HasForeignKey(p => p.IdRota)
                    .IsRequired();
            });


            modelBuilder.Entity<CaminhaoModel>(entity =>
            {
                entity.ToTable("Caminhao");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Modelo).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Capacidade).IsRequired();
                entity.Property(p => p.Placa).IsRequired().HasMaxLength(7);
                entity.HasOne(e => e.Rota).WithMany().HasForeignKey(e => e.IdRota).IsRequired();
            });


            modelBuilder.Entity<ColetaModel>(entity =>
            {
                entity.ToTable("Coleta");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.DataColeta).IsRequired().HasMaxLength(10);
                entity.HasOne(e => e.Caminhao).WithMany().HasForeignKey(e => e.IdCaminhao).IsRequired();
                entity.HasOne(e => e.Lixeira).WithMany().HasForeignKey(e => e.IdLixeira).IsRequired();
            });

            modelBuilder.Entity<UsuarioModel>(entity => {
                entity.ToTable("Usuario");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Email).IsRequired().HasMaxLength(100);
                entity.HasIndex(p => p.Email).IsUnique();
                entity.Property(p => p.Senha).IsRequired().HasMaxLength(255);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
