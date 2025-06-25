using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Model
{
    public enum TipoUtilizador
    {
        ADMINISTRADOR,
        UTENTE,
        ADMINISTRATIVO
    }

    [Table("Utilizadores")]
    public class Utilizador: IdentityUser<int>
    {
        [Key]
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Morada { get; set; }
        public string? UrlDaFotografia { get; set; }
        public Boolean EstadoDoUtilizador { get; set; }
        public TipoUtilizador TipoUtilizador { get; set; }
    }

}