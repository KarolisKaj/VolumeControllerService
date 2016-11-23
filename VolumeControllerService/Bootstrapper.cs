namespace VolumeControllerService
{
    using System.ComponentModel.Composition.Hosting;
    using Topshelf;
    using Utility;
    using Values;

    // Windows REmote Management - Compatibility Mode (HTTP-In) in firewall inbound must be enabled.
    public class Bootstrapper
    {
        public Bootstrapper()
        {
            new Shutdown(() => Container?.Dispose());
            FireWall.CreateException(System.AppDomain.CurrentDomain.BaseDirectory + System.AppDomain.CurrentDomain.FriendlyName);
            InitializeService(Container.GetExportedValue<IService>());
        }

        public CompositionContainer Container { get; set; } = new CompositionContainer(new ApplicationCatalog());

        private void InitializeService(IService service)
        {
            HostFactory.Run(x =>
            {
                x.Service<IService>(s =>
                {
                    s.ConstructUsing(name => service);
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Control volume via remote access point.");
                x.SetDisplayName(ApplicationData.ServiceName);
                x.SetServiceName(ApplicationData.ServiceName);
            });
        }

    }
}
