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
        private readonly ILocalVolumeService _localVolumeService;
        private readonly IDiscoveryService _discoveryService;

        // TODO: Inject logger into ctor.
        [ImportingConstructor]
        public VolumeControllerService(ILocalVolumeService localVolumeService, IDiscoveryService discoveryService)
        {
            _discoveryService = discoveryService;
            _localVolumeService = localVolumeService;
        }

        public void Dispose()
        {
            _listener?.Dispose();
            _observable?.Dispose();
            _discoveryService?.Dispose();
        }

        public void Start()
        {
            _discoveryService.Start();
            VolumeController.LocalVolumeService = _localVolumeService;
            _observable = _localVolumeService
                .VolumeObservable
                .Subscribe(v =>
                {
                    // GET REQUESTS TO PHONE
                    //_discoveryService.ClientIP
                });
            try
            {
                _listener = InitializeListener(CommuncationDetails.FullURL);
            }
            catch (Exception ex)
            {
                // TODO: Log.
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
