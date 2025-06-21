using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Model
{
    [Table("UtentesRegistado")]
    public class UtenteRegistado
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Uitlizadores")]
        public int IdUsuario { get; set; }
        public List<PedidoDeMarcacao> HistoricoDePedidoDeMarcacao { get; set; }

        public Utilizador? Utilizador { get; set; }
    }

    
}