using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Model
{
    public enum EstadoDoPedidoDeMarcacao
    {
        PEDIDO,
        AGENDADO,
        REALIZADO
    }

   public class PedidoDeMarcacao
   {
        [Key]
        public int Id { get; set; }

        public EstadoDoPedidoDeMarcacao EstadoDoPedidoDeMarcacao { get; set; }
        public DateTime DataDeCriacaoDoPedidoMarcacao { get; set; }
        public string Observacoes { get; set; }
        public string IntervaloDeDatasDoPedidoDeMarcacao { get; set; }
        public DateTime DataDeAgendamentoDoPedidoDeMarcacao { get; set; }

        public int? IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Utilizador Utilizador { get; set; }  
         
        public int? UtenteRegistadoId { get; set; }
        public UtenteRegistado? Utente { get; set; }

        public int? AdminstractivoId { get; set; }
        public Adminstractivo? Adminstractivo { get; set; }


        public ICollection<ActoClinico> ActosClinico { get; set; }
    }

}
