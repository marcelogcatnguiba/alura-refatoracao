using FluentResults;

namespace Alura.Adopet.Console.SuccessResult
{
    public class SuccessImport<T>(IEnumerable<T> entities) : Success
    {
        public IEnumerable<T> Entities { get; set; } = entities;
    }
}