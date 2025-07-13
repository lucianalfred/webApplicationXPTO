using DTO;

namespace Interfaces.Services
{
    public interface IPedidoDeMarcacaoService
    {
        IEnumerable<PedidoDeMarcacaoDTO> GetAll();
        PedidoDeMarcacaoDTO GetById(int id);
        IEnumerable<PedidoDeMarcacaoDTO> GetByUsuario(int idUsuario);
        Task<bool> Save(PedidoDeMarcacaoDTO dto);
        bool Update(PedidoDeMarcacaoDTO dto);
        bool Delete(int id);
        Task<bool> SaveAnonimo(PedidoDeMarcacaoAnonimoDTO dto);
        Task<bool> AgendarAsync(int id, DateTime data);

    }
}
