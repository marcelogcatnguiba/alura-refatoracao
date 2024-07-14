using System.Text.Json.Serialization;

namespace Alura.Adopet.Console.Entities
{
    public class Pet(Guid id, string? nome, TipoPet tipo)
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = id;

        [JsonPropertyName("nome")]
        public string? Nome { get; set; } = nome;

        [JsonPropertyName("tipo")]
        public TipoPet Tipo { get; set; } = tipo;
        
        public override string ToString()
        {
            return $"{Id} - {Nome} - {Tipo}";
        }
    }
}
