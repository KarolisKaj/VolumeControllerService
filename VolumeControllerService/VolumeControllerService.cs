namespace VolumeControllerService
{
    using Microsoft.Owin.Hosting;
    using REST;
    using Services;
    using System.ComponentModel.Composition;
    using System;
    using Observer;
    [Export(typeof(IService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class VolumeControllerService : IService
    {
        private IDisposable _listener;
        private IDisposable _observable;

        [Import]
        public ILocalVolumeService LocalVolumeService { get; set; }
        public void Start()
        {
            VolumeController.LocalVolumeService = LocalVolumeService;
            LocalVolumeService.SetVolumeLevel(0);
            _observable = LocalVolumeService
                .VolumeObservable
                .Subscribe(v =>
                {
                    // GET REQUESTS TO PHONE
                });
            try
            {
                _listener = InitializeListener("http://localhost/");
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
            _observable?.Dispose();
        }

        private IDisposable InitializeListener(string baseURL) => WebApp.Start<StartUpConfig>(baseURL);
    }
}
