namespace DTO
{
    public class UtenteRegistadoDto
    {
        public int NumeroUtente { get; set; }
        public int IdUsuario { get; set; }
        public String Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }

    public class CriarUtenteRegistadoDto
    {
        public int IdUsuario { get; set; }
    } 
}