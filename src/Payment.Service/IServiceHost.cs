using System;

namespace Payment.Service
{
    public interface IServiceHost : IDisposable
    {
        void Start();
        void Stop();
        void Shutdown();
    }
}
