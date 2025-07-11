using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL.Repositories
{
    public class UtenteRegistadoRepository : IUtenteRegistadoRepository
    {
        private readonly MarcacoesOnlineDbContext  _context;

        public UtenteRegistadoRepository(MarcacoesOnlineDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UtenteRegistado>> GetAllAsync()
        {
            return await _context.UtentesRegistados
                .Include(u => u.Utilizador)
                .ToListAsync();
        }

        public async Task<UtenteRegistado?> GetByIdAsync(int id)
        {
            return await _context.UtentesRegistados
                .Include(u => u.Utilizador)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> SaveAsync(UtenteRegistado utente)
        {
            _context.UtentesRegistados.Add(utente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(UtenteRegistado utente)
        {
            _context.UtentesRegistados.Update(utente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(UtenteRegistado utente)
        {
            _context.UtentesRegistados.Remove(utente);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
