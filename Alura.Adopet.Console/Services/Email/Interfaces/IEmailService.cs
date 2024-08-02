namespace Alura.Adopet.Console.Services.Email.Interfaces
{
    public interface IEmailService
    {
        Task EnviarEmail(string remetente, string destinatario, string titulo, string corpo);
    }
}