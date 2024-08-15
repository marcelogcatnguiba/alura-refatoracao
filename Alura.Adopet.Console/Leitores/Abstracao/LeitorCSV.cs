using System.ComponentModel;
using System.Reflection;
using Alura.Adopet.Console.Extensions;
using Alura.Adopet.Console.Leitores.Interfaces;

namespace Alura.Adopet.Console.Leitores.Abstracao
{
    public abstract class LeitorCSV<T>(string caminhoDoArquivo) : ILeitor<T>
    {
        private readonly string _caminhoDoArquivo = caminhoDoArquivo;
        
        public virtual IEnumerable<T> RealizarLeitura()
        {
            List<T> result = [];
            using (StreamReader sr = new (_caminhoDoArquivo))
            {
                var primeiraLinha = sr.ReadLine()!.Trim();
                string[] cabecalho = primeiraLinha.Split(';');

                while(!sr.EndOfStream)
                {
                    string linha = sr.ReadLine()!.Trim();
                    string[] dados = linha.Split(';');

                    var obj = RetornaClassFromLine(cabecalho, dados);
                    result.Add(obj);
                }
            }

            return result;
        }

        public T RetornaClassFromLine(string[] cabecalho, string[] dados)
        {
            Dictionary<PropertyInfo, object> valores = [];

            for (int i = 0; i < cabecalho.Length; i++)
            {
                var propriedade = cabecalho[i];
                PropertyInfo propertyInfo = typeof(T).GetProperty(propriedade)!;

                if(propertyInfo != null)
                {
                    Type propertyType = propertyInfo.PropertyType;
                    var valorPropriedade = dados[i];
                    var valorConvertido = TypeDescriptor.GetConverter(propertyType).ConvertFromInvariantString(valorPropriedade);
                                        
                    valores[propertyInfo] = valorConvertido!;
                }
            }

            var constructor = typeof(T).GetConstructors().First();
            var parameters = constructor.GetParameters();
            
            object[] constructorParams = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var param = parameters[i];
                if (valores.TryGetValue(typeof(T).GetProperty(param.Name!.PrimeiraLetraMaiuscula())!, out var value))
                {
                    constructorParams[i] = value;
                }
                else
                {
                    throw new Exception($"Faltando valor para o parâmetro: {param.Name}");
                }
            }
            
            return (T)constructor.Invoke(constructorParams);
        }
    }
}