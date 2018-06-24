using System.Configuration;

namespace Payment.Core
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public string ServiceName => ConfigurationManager.AppSettings["ServiceName"];
    }
}
