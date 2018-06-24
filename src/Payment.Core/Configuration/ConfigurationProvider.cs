using System.Configuration;

namespace Payment.Core.Configuration
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public string ServiceName => ConfigurationManager.AppSettings["ServiceName"];
        public string SecureFolderPath => ConfigurationManager.AppSettings["SecureFolderPath"];
    }
}
