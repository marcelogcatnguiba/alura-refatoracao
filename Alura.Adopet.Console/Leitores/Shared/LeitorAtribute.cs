namespace Alura.Adopet.Console.Leitores.Shared
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LeitorAtribute(string extensaoArquivo) : Attribute
    {
        public string ExtensaoArquivo { get; set; } = extensaoArquivo;
    }
}