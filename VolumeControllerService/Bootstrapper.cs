namespace VolumeControllerService
{
    using System.ComponentModel.Composition.Hosting;
    using Topshelf;

    public class Bootstrapper
    {
        public Bootstrapper()
        {
            InitializeService(Container.GetExportedValue<IService>());
            FreeUpDependencies();
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
                x.SetDisplayName("VolumeControllerService");
                x.SetServiceName("VolumeControllerService");
            });
        }

        private void FreeUpDependencies() => Container?.Dispose();
    }
}
