using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Threading.Tasks;

namespace Services
{
    public class EmailService
    {
        private readonly string _smtpHost = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _smtpUser = "clinicaxptoxpto@gmail.com";
        private readonly string _smtpPassword = "tihg fgel qdga wqpk ";
        public async Task EnviarConfirmacaoPedidoAsync(string destinatario, string nomeUtente, string numeroUtente)
        {
            if (string.IsNullOrWhiteSpace(destinatario) || string.IsNullOrWhiteSpace(nomeUtente) || string.IsNullOrWhiteSpace(numeroUtente))
                throw new ArgumentException("Dados inválidos para envio de e-mail.");

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Clínica XPTO", _smtpUser));
            message.To.Add(new MailboxAddress(nomeUtente, destinatario));
            message.Subject = "Confirmação do Pedido de Marcação";

            // Corpo do e-mail em HTML + alternativa em texto simples
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $@"
                <p>Olá <strong>{nomeUtente}</strong>,</p>
                <p>Recebemos o seu pedido de marcação com sucesso.</p>
                <p><strong>Número de utente:</strong> {numeroUtente}</p>
                <p>Entraremos em contacto em breve.</p>
                <br>
                <p>Obrigado,<br>Clínica XPTO</p>",
                TextBody = $"Olá {nomeUtente},\n\nRecebemos o seu pedido de marcação com sucesso.\nNúmero de utente: {numeroUtente}\n\nEntraremos em contacto em breve.\n\nObrigado,\nClínica XPTO"
            };

            message.Body = bodyBuilder.ToMessageBody();

            try
            {
                using var client = new SmtpClient();

                // Timeout opcional e segurança extra
                client.Timeout = 10000; // 10 segundos
                await client.ConnectAsync(_smtpHost, _smtpPort, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_smtpUser, _smtpPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                Console.WriteLine("E-mail enviado com sucesso para " + destinatario);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Erro ao enviar e-mail: " + ex.Message);
                throw;
            }
        }
    }
}