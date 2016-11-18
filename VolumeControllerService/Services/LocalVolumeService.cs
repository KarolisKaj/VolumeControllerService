namespace VolumeControllerService.Services
{
    using System;
    using System.ComponentModel.Composition;

    [Export(typeof(ILocalVolumeService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class LocalVolumeService : ILocalVolumeService
    {
        public int GetVolumeLevel()
        {
            return 0;
        }

        public bool SetVolumeLevel()
        {
            throw new NotImplementedException();
        }
    }
}
