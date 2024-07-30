namespace Alura.Adopet.Console.Readers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LeitorAtribute(string extensaoArquivo) : Attribute
    {
        public string ExtensaoArquivo { get; set; } = extensaoArquivo;
    }
}