public class PedidoDeMarcacaoService : IPedidoDeMarcacaoService
{
    private readonly IPedidoDeMarcacaoRepository _repository;

    public PedidoDeMarcacaoService(IPedidoDeMarcacaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<PedidoDeMarcacaoDTO>> ObterTodosAsync()
    {
        var pedidos = await _repository.ObterTodosAsync();
        return pedidos.Select(p => MapToDTO(p)).ToList();
    }

}
