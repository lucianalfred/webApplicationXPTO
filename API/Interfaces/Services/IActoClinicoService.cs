using DTO;

namespace Interfaces.Services
{
    public interface IActoClinicoService
    {
        Task<List<ActoClinicoDTO>> ObterTodosAsync();
        Task<ActoClinicoDTO> ObterPorIdAsync(int id);
        Task<bool> CriarAsync(ActoClinicoDTO acto);
        Task<bool> AtualizarAsync(ActoClinicoDTO acto);
        Task<bool> RemoverAsync(int id);
    }
}
