namespace Alura.Adopet.Console.Services
{
    public interface IComando
    {
        public Task ExecutarComando(string[] args);
    }
}