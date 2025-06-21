using DTO;

namespace Interfaces.Services
{
    public interface IPedidoDeMarcacaoService
    {
        IEnumerable<PedidoDeMarcacaoDTO> GetAll();
        PedidoDeMarcacaoDTO GetById(int id);
        bool Save(PedidoDeMarcacaoDTO dto);
        bool Update(PedidoDeMarcacaoDTO dto);
        bool Delete(int id);
    }
}
