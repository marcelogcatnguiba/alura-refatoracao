using System.Net.Mail;
using Alura.Adopet.Console.Services.Email.Interfaces;

namespace Alura.Adopet.Console.Services.Email
{
    public class SmtpEmailService(SmtpClient smtpClient) : IEmailService
    {
        private readonly SmtpClient _smptClient = smtpClient;
        public Task EnviarEmail(string remetente, string destinatario, string titulo, string corpo)
        {
            var mailMessage = new MailMessage()
            {
                From = new MailAddress(remetente),
                Subject = titulo,
                Body = corpo
            };

            mailMessage.To.Add(new MailAddress(destinatario));
            _smptClient.Send(mailMessage);
            return Task.CompletedTask;
        }
    }
}