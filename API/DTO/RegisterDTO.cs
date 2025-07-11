public class RegisterDTO
{
    public string Nome { get; set; }

    public string Email { get; set; }  // Adiciona o campo Email que é essencial no Identity

    public string Password { get; set; }

    public DateTime DataNascimento { get; set; }

    public string Morada { get; set; }

    public string Genero { get; set; }

    public string Telefone { get; set; }  // Inclua para evitar erro de "Telefone inexistente"

    public string Papel { get; set; }  // Deve ser: "Utente", "Administrador" ou "Administrativo"

    public bool EstadoDoUtilizador { get; set; }  // Remova o nullable (requerido pela entidade)
}
