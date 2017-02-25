using System;
using System.ComponentModel.Composition;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VolumeControllerService.Values;

namespace VolumeControllerService.Services
{
    [Export(typeof(IDiscoveryService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class DiscoveryService : IDiscoveryService
    {
        private readonly ManualResetEvent _resetEvent = new ManualResetEvent(false);
        private const string Message = "Received. I am Volume control server!";
        private const string ClientMessage = "Volume Controller Service Discovery String.";
        private UdpClient _udpClient;



        public void Start()
        {
            Task.Run(() => StartListening());
        }

        private void StartListening()
        {
            try
            {
                var broadcastAddress = new IPEndPoint(IPAddress.Any, CommuncationDetails.PortUDP);
                _udpClient = new UdpClient();
                _udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                _udpClient.ExclusiveAddressUse = false;
                _udpClient.Client.Bind(broadcastAddress);
                while (true)
                {
                    _resetEvent.Reset();
                    _udpClient.BeginReceive(new AsyncCallback(ReceiveCallback), _udpClient);
                    _resetEvent.WaitOne();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                // Log
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                IPEndPoint client = new IPEndPoint(IPAddress.Any, CommuncationDetails.PortUDP);
                var clientMessage = _udpClient.EndReceive(ar, ref client);
                if (Encoding.ASCII.GetString(clientMessage) == ClientMessage)
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(Message);
                    client.Port = CommuncationDetails.PortUDP;
                    var temp = new UdpClient();
                    temp.Connect(client);
                    temp.Send(bytes, bytes.Length);
                }
            }
            catch (Exception ex)
            {

            }
            _resetEvent.Set();
            // Return Volume Controlled Server. Confirmed.
        }

        public void Dispose()
        {
            _udpClient?.Close();
        }
    }
}
