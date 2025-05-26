Using Model;

namespace Interfaces
{
    public interface IPedidoDeMarcacaoRepository
    {
        Task<List<PedidoDeMarcacao>> ObterTodosAsync();
        Task<PedidoDeMarcacao> ObterPorIdAsync(int id);
        Task<PedidoDeMarcacao> CriarAsync(PedidoDeMarcacao pedido);
        Task AtualizarAsync(PedidoDeMarcacao pedido);
        Task RemoverAsync(PedidoDeMarcacao pedido);
    }
}