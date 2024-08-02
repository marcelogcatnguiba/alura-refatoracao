using System.Dynamic;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Alura.Adopet.Console.Settings
{
    public static class Configurations
    {
        public static AppSettings ApiSettings
        {
            get
            {
                var config = BuildConfiguration();
            
                return config
                    .GetSection(AppSettings.Section)
                    .Get<AppSettings>() ?? throw new ArgumentException("Secao de configuracao invalida");
            }
        }

        //Configura o carregamento o JSON de appsettings 
        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}