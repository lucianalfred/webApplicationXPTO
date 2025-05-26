using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Table")]
    public class Adminstractivo
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Utilizador")]
        public int UtilizadorId { get; set;}
    }
    
}