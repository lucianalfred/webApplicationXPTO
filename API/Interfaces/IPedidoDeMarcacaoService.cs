using DTO;

namespace Interfaces
{
    public interface IPedidoDeMarcacaoService
    {
        Task<List<PedidoDeMarcacaoDTO>> ObterTodosAsync();
        Task<PedidoDeMarcacaoDTO> ObterPorIdAsync(int id);
        Task<PedidoDeMarcacaoDTO> CriarAsync(PedidoDeMarcacaoDTO novoPedido);
        Task<bool> AtualizarAsync(PedidoDeMarcacaoDTO pedidoAtualizado);
        Task<bool> RemoverAsync(int id);
    }

    
}