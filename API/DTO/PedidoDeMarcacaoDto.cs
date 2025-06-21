using Model;

namespace DTO
{
    public class PedidoDeMarcacaoDTO
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public DateTime DataCriacao { get; set; }
        public string IntervaloDatas { get; set; }
        public string Observacoes { get; set; }
        public int? UtenteRegistadoId { get; set; }
        public int? AdminstractivoId { get; set; }
        public DateTime DataAgendamento { get; set; }
        public List<int>? ActosClinicoIds { get; set; }
        public ICollection<ActoClinico> ActosClinico { get; set; }
    
    }
}
