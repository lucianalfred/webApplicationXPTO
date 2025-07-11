using DTO;

namespace Interfaces.Repositories
{
    public interface IProfissionalRepository
    {
        Task<List<ProfissionalDTO>> ObterTodosAsync();
        Task<ProfissionalDTO> ObterPorIdAsync(int id);
        Task<bool> CriarAsync(ProfissionalDTO profissional);
        Task<bool> AtualizarAsync(ProfissionalDTO profissional);
        Task<bool> RemoverAsync(int id);
    }
}
