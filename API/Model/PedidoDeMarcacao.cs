using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model;

namespace Model
{
    public enum EstadoDoPedidoDeMarcacao
    {
        PEDIDO,
        AGENDADO,
        REALIZADO
    }

    [Table("PedidosDeMarcacao")]
    public class PedidoDeMarcacao
    {
        [Key]
        public int Id { get; set; }
        public EstadoDoPedidoDeMarcacao EstadoDoPedidoDeMarcacao { get; set; }
        public DateTime DataDeCriacaoDoPedidoMarcacao { get; set; }
        public string IntervaloDeDatasDoPedidoDeMarcacao { get; set; }
        public string Observacoes { get; set; }
        public UtenteRegistado ? Utente;
        public List<ActoClinico> ActosClinico { get; set; }
        public Adminstractivo? Adminstractivo { get; set; }
        public DateTime DataDeAgendamentoDoPedidoDeMarcacao { get; set; }
    }

}