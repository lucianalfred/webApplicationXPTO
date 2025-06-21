using DTO;

namespace Interfaces.Services
{
    public interface IProfissionalService
    {
        Task<List<ProfissionalDTO>> ObterTodosAsync();
        Task<ProfissionalDTO> ObterPorIdAsync(int id);
        Task<bool> CriarAsync(ProfissionalDTO profissional);
        Task<bool> AtualizarAsync(ProfissionalDTO profissional);
        Task<bool> RemoverAsync(int id);
    }
}
