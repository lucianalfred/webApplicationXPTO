using System.Threading.Tasks;

namespace Interfaces.Repositories
{
    public interface IEmailRepository
    {
        Task<bool> EnviarConfirmacaoPedidoAsync(string destinatario, string nomeUtente, string numeroUtente);
    }
}
