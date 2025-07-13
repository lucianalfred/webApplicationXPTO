using DTO;
using Model;

namespace Interfaces.Repositories
{
    public interface IUtilizadorRepository
    {
        Task<List<UtilizadorDTO>> ObterTodosAsync();
        Task<UtilizadorDTO> ObterPorIdAsync(int id);
        Task<bool> CriarAsync(UtilizadorDTO utilizador);
        Task<bool> AtualizarAsync(UtilizadorDTO utilizador);
        Task<bool> RemoverAsync(int id);
    
    }
}
