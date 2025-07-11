using Model;

namespace Interfaces.Repositories
{
    public interface IPedidoDeMarcacaoRepository
    {
        Task<IEnumerable<PedidoDeMarcacao>> GetAllAsync();
        Task<PedidoDeMarcacao?> GetByIdAsync(int id);
        Task<bool> SaveAsync(PedidoDeMarcacao pedido);
        Task<bool> UpdateAsync(PedidoDeMarcacao pedido);
        Task<bool> DeleteAsync(PedidoDeMarcacao pedido);
        Task<bool> SaveAnonimoAsync(PedidoDeMarcacao pedido);
    }

}
