using FluentResults;

namespace Alura.Adopet.Console.SuccessResult
{
    public class SuccessImport<T>(IEnumerable<T> pets) : Success
    {
        public IEnumerable<T> Pets { get; set; } = pets;
    }
}