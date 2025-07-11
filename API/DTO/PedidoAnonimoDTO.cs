using Model;
using DTO;
public class PedidoDeMarcacaoAnonimoDTO
{
    public string NumeroUtente { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Genero { get; set; }
    public string IntervaloDatas { get; set; }
    public string HorarioSolicitado { get; set; }
    public string Observacoes { get; set; }
    public UtilizadorDTO Utente { get; set; }
    public List<ActoClinicoDTO> ActosClinicos { get; set; }
}
