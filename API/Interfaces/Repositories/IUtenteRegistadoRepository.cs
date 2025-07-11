using Model;

namespace Interfaces.Repositories
{
    public interface IUtenteRegistadoRepository
    {
        Task<IEnumerable<UtenteRegistado>> GetAllAsync();
        Task<UtenteRegistado?> GetByIdAsync(int id);
        Task<bool> SaveAsync(UtenteRegistado utente);
        Task<bool> UpdateAsync(UtenteRegistado utente);
        Task<bool> DeleteAsync(UtenteRegistado utente);
    }
}
