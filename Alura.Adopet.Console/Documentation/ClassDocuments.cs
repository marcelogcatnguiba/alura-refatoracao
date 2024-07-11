namespace Alura.Adopet.Console.Documentation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ClassDocuments : Attribute
    {
        public string Comando { get; set; } = "";
        public string Descricao { get; set; } = "";

        public ClassDocuments(string comando, string descricao)
        {
            Comando = comando;
            Descricao = descricao;
        }
    }
}