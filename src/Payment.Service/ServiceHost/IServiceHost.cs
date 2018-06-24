namespace Payment.Service.ServiceHost
{
    public interface IServiceHost
    {
        void Start();
        void Stop();
        void Shutdown();
    }
}
