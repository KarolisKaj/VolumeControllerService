using System;
using System.Net;

namespace VolumeControllerService.Services
{
    public interface IDiscoveryService : IDisposable
    {
        void Start();
        IPAddress ClientIP { get; }
    }
}
