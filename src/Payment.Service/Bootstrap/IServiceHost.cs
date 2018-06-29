namespace Payment.Service.Bootstrap
{
    public interface IServiceHost
    {
        void Start();
        void Stop();
        void Shutdown();
    }
}
