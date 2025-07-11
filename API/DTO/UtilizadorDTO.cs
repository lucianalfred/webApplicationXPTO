using Model;

namespace DTO
{
    public class UtilizadorDTO
    {
        public string Nome { get; set; }
        public string Password { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Morada { get; set; }
        public string Telefone { get; set; }
        public string? UrlDaFotografia { get; set; }
        public bool? EstadoDoUtilizador { get; set; }
        public string TipoUtilizador { get; set; } 
    }
}
