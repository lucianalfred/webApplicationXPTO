using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model
{
    [Table("Administradores")]
    public class Administrador: Utilizador
    {
        public int Id {get; set;}

        [ForeignKey("Utilizador")]
        public int UtilizadorId { get; set;}
    }
}