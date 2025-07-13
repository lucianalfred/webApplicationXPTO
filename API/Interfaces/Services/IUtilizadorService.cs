using DTO;
using Model;

namespace Interfaces.Services
{

    public interface IUtilizadorService
    {
        Task<IEnumerable<UtilizadorDTO>> ObterTodosAsync();
        Task<UtilizadorDTO?>             ObterPorIdAsync(int id);
        Task<bool>                       CriarAsync(UtilizadorDTO dto);
        Task<bool>                       AtualizarAsync(UtilizadorDTO dto);
        Task<bool>                       RemoverAsync(int id);
    }

}
