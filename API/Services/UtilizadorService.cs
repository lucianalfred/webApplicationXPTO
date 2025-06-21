using DTO;
using Interfaces.Repositories;
using Interfaces.Services;

namespace Services
{
    public class UtilizadorService : IUtilizadorService
    {
        private readonly IUtilizadorRepository _repository;

        public UtilizadorService(IUtilizadorRepository repository)
        {
            _repository = repository;
        }

        public Task<List<UtilizadorDTO>> ObterTodosAsync() => _repository.ObterTodosAsync();
        public Task<UtilizadorDTO> ObterPorIdAsync(int id) => _repository.ObterPorIdAsync(id);
        public Task<bool> CriarAsync(UtilizadorDTO utilizador) => _repository.CriarAsync(utilizador);
        public Task<bool> AtualizarAsync(UtilizadorDTO utilizador) => _repository.AtualizarAsync(utilizador);
        public Task<bool> RemoverAsync(int id) => _repository.RemoverAsync(id);
    }
}
