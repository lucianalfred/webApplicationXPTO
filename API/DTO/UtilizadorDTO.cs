using Model;

namespace DTO
{
    public class UtilizadorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Morada { get; set; }
        public string? UrlDaFotografia { get; set; }
        public bool EstadoDoUtilizador { get; set; }
        public TipoUtilizador TipoUtilizador { get; set; } 
    }
}
