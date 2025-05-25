using Model;

namespace DTO
{
    public class PedidoDeMarcacaoDto
    {
        public int Id { get; set; }
        public EstadoDoPedidoDeMarcacao EstadoDoPedidoDeMarcacao { get; set; }
        public DateTime DataDeCriacaoDoPedidoMarcacao { get; set; }
        public string IntervaloDeDatasDoPedidoDeMarcacao { get; set; } = string.Empty;
        public string Observacoes { get; set; } = string.Empty;
        public UtenteRegistado? Utente;
        public List<ActoClinico> ActosClinico { get; set; } = new();
        public Adminstractivo? Adminstractivo { get; set; }
        public DateTime DataDeAgendamentoDoPedidoDeMarcacao { get; set; }
    }
}