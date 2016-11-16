namespace VolumeControllerService
{
    using System;
    using System.ComponentModel.Composition;
    using System.Net;
    using System.Threading.Tasks;

    [Export(typeof(IService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class VolumeController : IService
    {
        private HttpListener _listener;
        public void Start()
        {
            CreateHttpListener();
            InitializeListening();
        }

        public void Stop()
        {
            _listener?.Stop();
            _listener?.Close();
            (_listener as IDisposable)?.Dispose();
        }

        public void CreateHttpListener()
        {
            _listener = new HttpListener
            {
                Prefixes = {  "http://volumecontroller.com/Request/" },
            };
        }

        private void InitializeListening()
        {
            _listener.Start();

            //Task.Run(() =>
            //{
                while (_listener.IsListening)
                {
                    var context = _listener.GetContext();
                    Console.WriteLine(context.Request);
                }
            //});
        }
    }
}
