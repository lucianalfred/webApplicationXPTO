namespace DTO
{
    public class ActoClinicoDTO
    {
        public int Id { get; set; }
        public string TipoDeActoClinico { get; set; }
        public string? SubSistemaDeSaude { get; set; }
        public string? Observacoes { get; set; }
        public int PedidoDeMarcacaoId { get; set; }
    }
}
