using Model;

public class PedidoDeMarcacaoDTO
{
    public int Id { get; set; }
    public EstadoDoPedidoDeMarcacao EstadoDoPedidoDeMarcacao { get; set; }
    public DateTime DataDeCriacaoDoPedidoMarcacao { get; set; }

    public string IntervaloDeDatasDoPedidoDeMarcacao { get; set; }
    public string Observacoes { get; set; }

    public int? UtenteRegistadoId { get; set; }
    public int? AdminstractivoId { get; set; }

    public List<int> ActosClinicoIds { get; set; }
    public DateTime DataDeAgendamentoDoPedidoDeMarcacao { get; set; }
}
