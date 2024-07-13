using Alura.Adopet.Console.Readers.Interfaces;

namespace Alura.Adopet.Console.Factory.Reader
{
    public abstract class ReaderFactory
    {
        public abstract ILeitor CriarLeitor();
    }
}