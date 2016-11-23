namespace VolumeControllerService
{
    using Microsoft.Owin.Hosting;
    using REST;
    using Services;
    using System.ComponentModel.Composition;
    using System;
    using Observer;
    using Values;

    [Export(typeof(IService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class VolumeControllerService : IService, IDisposable
    {
        private IDisposable _listener;
        private IDisposable _observable;

        [Import]
        public ILocalVolumeService LocalVolumeService { get; set; }

        public void Dispose()
        {
            _listener?.Dispose();
            _observable?.Dispose();
        }

        public void Start()
        {
            VolumeController.LocalVolumeService = LocalVolumeService;
            _observable = LocalVolumeService
                .VolumeObservable
                .Subscribe(v =>
                {
                    // GET REQUESTS TO PHONE
                });
            try
            {
                _listener = InitializeListener(URLDetails.FullURL);
            }
            catch (Exception ex)
            {
                Stop();
                Console.WriteLine("App crashed, bye!");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void Stop() => Dispose();

        private IDisposable InitializeListener(string baseURL) => WebApp.Start<StartUpConfig>(baseURL);
    }
}
