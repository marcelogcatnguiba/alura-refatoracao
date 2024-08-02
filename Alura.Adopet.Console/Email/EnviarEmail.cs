using System.Net;
using System.Net.Mail;
using Alura.Adopet.Console.Services.Email;
using Alura.Adopet.Console.Services.Email.Interfaces;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Email
{
    public class EnviarEmail
    {
        public static IEmailService CriarEmailService()
        {
            EmailSettings emailSettings = Configurations.EmailSettings;

            SmtpClient smtpClient = new()
            {
                Host = emailSettings.Servidor,
                Port = emailSettings.Porta,
                Credentials = new NetworkCredential(emailSettings.Usuario, emailSettings.Senha),
                EnableSsl = true,
                UseDefaultCredentials = false
            };

            return new SmtpEmailService(smtpClient);
        }
    }
}