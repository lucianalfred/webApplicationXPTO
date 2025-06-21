using DTO;
using Interfaces;
using Interfaces.Repositories;
using Interfaces.Services;

namespace Services
{
    public class ActoClinicoService : IActoClinicoService
    {
        private readonly IActoClinicoRepository _repository;

        public ActoClinicoService(IActoClinicoRepository repository)
        {
            _repository = repository;
        }

        public Task<List<ActoClinicoDTO>> ObterTodosAsync() => _repository.ObterTodosAsync();
        public Task<ActoClinicoDTO> ObterPorIdAsync(int id) => _repository.ObterPorIdAsync(id);
        public Task<bool> CriarAsync(ActoClinicoDTO acto) => _repository.CriarAsync(acto);
        public Task<bool> AtualizarAsync(ActoClinicoDTO acto) => _repository.AtualizarAsync(acto);
        public Task<bool> RemoverAsync(int id) => _repository.RemoverAsync(id);
    }
}
