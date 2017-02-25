using System;

namespace VolumeControllerService.Services
{
    public interface IDiscoveryService : IDisposable
    {
        void Start();
    }
}
