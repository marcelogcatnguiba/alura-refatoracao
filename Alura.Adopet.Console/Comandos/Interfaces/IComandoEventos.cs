using FluentResults;

namespace Alura.Adopet.Console.Comandos.Interfaces
{
    public interface IComandoEventos
    {
        event Action<Result>? DepoisDaExecucao;
    }
}