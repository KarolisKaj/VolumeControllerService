namespace VolumeControllerService
{
    using Microsoft.Owin.Hosting;
    using REST;
    using System;
    using System.ComponentModel.Composition;
    [Export(typeof(IService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class VolumeControllerService : IService
    {
        private IDisposable _listener;
        public void Start()
        {
            try
            {
                InitializeListener("http://localhost/");
            }
            catch (Exception ex)
            {
                Stop();
                Console.WriteLine("App crashed, bye!");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void Stop()
        {
            _listener?.Dispose();
        }
        private void InitializeListener(string baseURL)
        {
            _listener = WebApp.Start<StartUpConfig>(baseURL);
        }
    }
}
