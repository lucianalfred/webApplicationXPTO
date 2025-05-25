using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Utilizadores")]
    public class Utilizador
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Morada { get; set; }
        public string? UrlDaFotografia { get; set; }
        public Boolean EstadoDoUtilizador { get; set; }

    }

}