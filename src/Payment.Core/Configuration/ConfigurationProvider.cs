using System.Configuration;

namespace Payment.Core.Configuration
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public string ServiceName => ConfigurationManager.AppSettings["ServiceName"];
        public string SecureFolderPath => ConfigurationManager.AppSettings["SecureFolderPath"];
        public string PaymentFileExportDay => ConfigurationManager.AppSettings["PaymentFileExportDay"];
        public string PaymentFilePathIdentity => ConfigurationManager.AppSettings["PaymentFilePathIdentity"];
    }
}
