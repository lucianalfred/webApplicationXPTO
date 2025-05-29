using Model;

namespace DTO
{
    public class PedidoDeMarcacaoDTO
    {
        public int Id { get; set; }
        public string EstadoDoPedidoDeMarcacao { get; set; }
        public DateTime DataDeCriacaoDoPedidoMarcacao { get; set; }
        public string IntervaloDeDatasDoPedidoDeMarcacao { get; set; }
        public string Observacoes { get; set; }
        public int? UtenteId { get; set; }
        public int? AdminstractivoId { get; set; }
        public DateTime DataDeAgendamentoDoPedidoDeMarcacao { get; set; }
    }
}
