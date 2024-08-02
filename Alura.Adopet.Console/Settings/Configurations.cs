using Microsoft.Extensions.Configuration;

namespace Alura.Adopet.Console.Settings
{
    public static class Configurations
    {
        public static ApiSettings ApiSettings
        {
            get
            {
                var config = BuildConfiguration();
            
                return config
                    .GetSection(ApiSettings.Section)
                    .Get<ApiSettings>() ?? throw new ArgumentException("Secao de configuracao invalida");
            }
        }

        public static EmailSettings EmailSettings
        {
            get
            {
                var config = BuildConfiguration();
                return config
                    .GetSection(EmailSettings.Section)
                    .Get<EmailSettings>() ?? throw new ArgumentException("Secao de configuracao invalida");
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