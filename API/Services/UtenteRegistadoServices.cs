using Microsoft.EntityFrameworkCore;
using Interfaces;
using Model;
using DAL;

namespace Services
{
    public class UtenteRegistadoService : IUtenteRegistadoService
    {
        private readonly MarcacoesOnlineDbContext _context;

        public UtenteRegistadoService(MarcacoesOnlineDbContext context)
        {
            _context = context;
        }

        public async Task<List<UtenteRegistado>> ObterTodosAsync()
        {
            return await _context.UtentesRegistados
                .Include(u => u.Utilizador)
                .ToListAsync();
        }

        public async Task<UtenteRegistado?> ObterPorNumeroAsync(int numero)
        {
            return await _context.UtentesRegistados
                .Include(u => u.Utilizador)
                .FirstOrDefaultAsync(u => u.NumeroUtente == numero);
        }

        public async Task<UtenteRegistado> CriarAsync(UtenteRegistado utente)
        {
            _context.UtentesRegistados.Add(utente);
            await _context.SaveChangesAsync();
            return utente;
        }
    }
}
