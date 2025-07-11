using DTO;

namespace Interfaces.Services
{
    public interface IUtenteRegistadoService
    {
        IEnumerable<UtenteRegistadoDTO> GetAll();
        UtenteRegistadoDTO? GetById(int id);
        bool Save(UtenteRegistadoDTO dto);
        bool Update(UtenteRegistadoDTO dto);
        bool Delete(int id);
    }
}
