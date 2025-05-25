using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("ActosClinico")]
    public class ActoClinico
    {
        [Key]
        public int Id { get; set; }
        public string TipoDeActoClinico { get; set; }
        public string? SubSistemaDeSaude { get; set; }
        public Profissional? Profissional { get; set; }
        public string? Observacoes { get; set; }
        
        public int PedidoDeMarcacaoId { get; set; } 
        public PedidoDeMarcacao PedidoDeMarcacao { get; set; }


    }
}