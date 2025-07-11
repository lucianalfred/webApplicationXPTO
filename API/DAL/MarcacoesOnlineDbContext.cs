using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Model;

namespace DAL
{
    public class MarcacoesOnlineDbContext : IdentityDbContext<Utilizador,ApplicationRole, int>
    {
        public MarcacoesOnlineDbContext(DbContextOptions<MarcacoesOnlineDbContext> options) : base(options) { }
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<UtenteRegistado> UtentesRegistados { get; set; }
        public DbSet<PedidoDeMarcacao> PedidosDeMarcacao { get; set; }
        public DbSet<ActoClinico> ActosClinico { get; set; }
        public DbSet<Adminstractivo> Adminstractivos { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UtenteRegistado>()
                .HasOne(u => u.Utilizador)
                .WithMany()
                .HasForeignKey(u => u.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PedidoDeMarcacao>()
                .HasOne(p => p.Utente)
                .WithMany()
                .HasForeignKey(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);
   
        }
        
    }
}
