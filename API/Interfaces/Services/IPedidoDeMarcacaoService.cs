using DTO;

namespace Interfaces.Services
{
    public interface IPedidoDeMarcacaoService
    {
        IEnumerable<PedidoDeMarcacaoDTO> GetAll();
        PedidoDeMarcacaoDTO GetById(int id);
        Task<bool> Save(PedidoDeMarcacaoDTO dto);
        bool Update(PedidoDeMarcacaoDTO dto);
        bool Delete(int id);
        Task<bool> SaveAnonimo(PedidoDeMarcacaoAnonimoDTO dto);
    }
}
