using FluentResults;

namespace Alura.Adopet.Console.SuccessResult
{
    public class SuccessImport<T>(IEnumerable<T> entities, string? message = null) : Success(message)
    {
        public IEnumerable<T> Entities { get; set; } = entities;

    }
}