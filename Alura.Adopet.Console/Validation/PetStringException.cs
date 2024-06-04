namespace Alura.Adopet.Console.Validation
{
    public class PetStringException : Exception
    {
        public PetStringException(string message) : base(message)
        {

        }

        public static void Quando(bool esseErro, string message)
        {
            if (esseErro) throw new PetStringException(message);
        }
    }
}