namespace Payment.Service
{
    public interface IServiceHost
    {
        void Start();
        void Stop();
        void Shutdown();
    }
}
