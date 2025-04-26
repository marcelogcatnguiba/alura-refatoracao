using System.Net;
using System.Net.Mail;
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Services.Email.Configuration;
using Alura.Adopet.Console.Services.Email.Interfaces;
using Alura.Adopet.Console.Settings;
using Alura.Adopet.Console.SuccessResult;
using FluentResults;

namespace Alura.Adopet.Console.Services.Email.Implementation
{
    public static class EnviarEmail
    {
        private static IEmailService CriarEmail()
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

        public static void DispararEmail(Result result)
        {
            var successes = result.Successes.FirstOrDefault();
            
            if(successes is null)
            {
                return;
            }

            if(successes is SuccessImport<Pet> pets)
            {
                var email = CriarEmail();
                email.EnviarEmail
                (
                    remetente: "marcelogomes.0104@gmail.com",
                    titulo: $"Adopet {pets.Message}",
                    corpo: $"Foram importados {pets.Entities.Count()} pets.",
                    destinatario: "marcelogomes.0104@gmail.com"
                );
            }
        }
    }
}