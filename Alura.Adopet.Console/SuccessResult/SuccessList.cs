using Alura.Adopet.Console.Entities;
using FluentResults;

namespace Alura.Adopet.Console.SuccessResult
{
    public class SuccessList(IEnumerable<Pet> pets) : Success
    {
        public IEnumerable<Pet> Pets { get; set; } = pets;
    }
}