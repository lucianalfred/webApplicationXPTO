using Model;

namespace Interfaces
{
    public interface IUtenteRegistadoService
    {
        Task<List<UtenteRegistado>> ObterTodosAsync();
        Task<UtenteRegistado?> ObterPorNumeroAsync(int numero);
        Task<UtenteRegistado> CriarAsync(UtenteRegistado utente);
    }
}
