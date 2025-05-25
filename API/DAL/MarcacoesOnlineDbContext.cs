using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL
{
    public class MarcacoesOnlineDbContext : DbContext
    {
        public MarcacoesOnlineDbContext(DbContextOptions<MarcacoesOnlineDbContext> options) : base(options) { }

        public DbSet<UtenteRegistado> UtentesRegistados { get; set; }
        public DbSet<PedidoDeMarcacao> PedidosDeMarcacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Utilizador>()
            .HasDiscriminator<string>("TipoUtilizador")
            .HasValue<Utilizador>("Utilizador")
            .HasValue<Administrador>("Administrador");

            modelBuilder.Entity<UtenteRegistado>()
                .HasOne(u => u.Utilizador)
                .WithMany()
                .HasForeignKey(u => u.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PedidoDeMarcacao>()
                .HasMany(p => p.ActosClinico)
                .WithOne(a => a.PedidoDeMarcacao)
                .HasForeignKey(a => a.PedidoDeMarcacaoId)
                .OnDelete(DeleteBehavior.Cascade);

            }
        
    }
}
