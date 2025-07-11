using DTO;
using Interfaces;
using Interfaces.Services;
using Interfaces.Repositories;
namespace Services
{
    public class ProfissionalService : IProfissionalService
    {
        private readonly IProfissionalRepository _repository;

        public ProfissionalService(IProfissionalRepository repository)
        {
            _repository = repository;
        }

        public Task<List<ProfissionalDTO>> ObterTodosAsync() => _repository.ObterTodosAsync();
        public Task<ProfissionalDTO> ObterPorIdAsync(int id) => _repository.ObterPorIdAsync(id);
        public Task<bool> CriarAsync(ProfissionalDTO profissional) => _repository.CriarAsync(profissional);
        public Task<bool> AtualizarAsync(ProfissionalDTO profissional) => _repository.AtualizarAsync(profissional);
        public Task<bool> RemoverAsync(int id) => _repository.RemoverAsync(id);
    }
}
