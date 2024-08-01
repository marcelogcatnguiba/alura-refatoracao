namespace Alura.Adopet.Console.Leitores
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LeitorAtribute(string extensaoArquivo) : Attribute
    {
        public string ExtensaoArquivo { get; set; } = extensaoArquivo;
    }
}