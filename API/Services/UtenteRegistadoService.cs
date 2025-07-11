using DTO;
using Interfaces.Repositories;
using Interfaces.Services;
using Model;

namespace Services
{
    public class UtenteRegistadoService : IUtenteRegistadoService
    {
        private readonly IUtenteRegistadoRepository _repository;

        public UtenteRegistadoService(IUtenteRegistadoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UtenteRegistadoDTO> GetAll()
        {
            return _repository.GetAllAsync().Result.Select(u => new UtenteRegistadoDTO
            {
                Id = u.Id,
                IdUsuario = u.IdUsuario,
                Nome = u.Utilizador?.Nome
            });
        }

        public UtenteRegistadoDTO? GetById(int id)
        {
            var utente = _repository.GetByIdAsync(id).Result;
            if (utente == null) return null;

            return new UtenteRegistadoDTO
            {
                Id = utente.Id,
                IdUsuario = utente.IdUsuario,
                Nome = utente.Utilizador?.Nome
            };
        }

        public bool Save(UtenteRegistadoDTO dto)
        {
            var utente = new UtenteRegistado
            {
                IdUsuario = dto.IdUsuario
            };

            return _repository.SaveAsync(utente).Result;
        }

        public bool Update(UtenteRegistadoDTO dto)
        {
            var utente = new UtenteRegistado
            {
                Id = dto.Id,
                IdUsuario = dto.IdUsuario
            };

            return _repository.UpdateAsync(utente).Result;
        }

        public bool Delete(int id)
        {
            var utente = _repository.GetByIdAsync(id).Result;
            if (utente == null) return false;

            return _repository.DeleteAsync(utente).Result;
        }
    }
}
