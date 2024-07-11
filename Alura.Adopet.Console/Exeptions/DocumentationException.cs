namespace Alura.Adopet.Console.Exeptions
{
    public class DocumentationException(string message) : Exception(message)
    {
        public static void Quando(bool esseErro, string message)
        {
            if(esseErro)
            {
                throw new DocumentationException(message);
            }
        }
    }
}