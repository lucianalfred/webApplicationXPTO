using Interfaces.Repositories;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        public async Task<bool> EnviarConfirmacaoPedidoAsync(string destinatario, string nomeUtente, string numeroUtente)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Clínica XPTO", "noreply@clinica.com"));
                message.To.Add(new MailboxAddress(nomeUtente, destinatario));
                message.Subject = "Confirmação de Pedido de Marcação";

                message.Body = new TextPart("plain")
                {
                    Text = $"Olá {nomeUtente},\n\nRecebemos o seu pedido de marcação com sucesso.\nNúmero de utente: {numeroUtente}\n\nEntraremos em contacto em breve.\n\nObrigado,\nClínica XPTO"
                };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.seuprovedor.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync("seuemail@clinica.com", "sua_senha");
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
                return false;
            }
        }
    }
}
