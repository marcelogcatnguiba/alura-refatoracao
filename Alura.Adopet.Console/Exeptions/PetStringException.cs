namespace Alura.Adopet.Console.Exeptions
{
    public class PetStringException(string message) : Exception(message)
    {
        public static void Quando(bool esseErro, string message)
        {
            if (esseErro) 
                throw new PetStringException(message);
        }

        internal static void Quando(object value, string v)
        {
            throw new NotImplementedException();
        }
    }
}