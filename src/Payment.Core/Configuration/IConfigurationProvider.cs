namespace Payment.Core.Configuration
{
    public interface IConfigurationProvider
    {
        string ServiceName { get; }
        string SecureFolderPath { get; }
    }
}
