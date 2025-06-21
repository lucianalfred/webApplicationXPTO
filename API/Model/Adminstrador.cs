using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model
{
    
    public class Administrador: Utilizador
    {
        public int Id {get; set;}

        [ForeignKey("Utilizador")]
        public int UtilizadorId { get; set;}
    }
}