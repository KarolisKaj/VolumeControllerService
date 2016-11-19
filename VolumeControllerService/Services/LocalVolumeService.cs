namespace VolumeControllerService.Services
{
    using AudioSwitcher.AudioApi;
    using AudioSwitcher.AudioApi.CoreAudio;
    using System;
    using System.ComponentModel.Composition;

    [Export(typeof(ILocalVolumeService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class LocalVolumeService : ILocalVolumeService
    {
        public LocalVolumeService()
        {
            PrimaryDevice = new CoreAudioController().DefaultPlaybackDevice;
            VolumeObservable = PrimaryDevice.VolumeChanged;
        }

        public int GetVolumeLevel() => (int)(PrimaryDevice.Volume);

        public bool SetVolumeLevel(int volume)
        {
            try
            {
                PrimaryDevice.Volume = volume;
                return (int)(PrimaryDevice.Volume) == volume;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Was not able to set volume.");
                return false;
            }
        }

        public IObservable<DeviceVolumeChangedArgs> VolumeObservable { get; }
        private CoreAudioDevice PrimaryDevice { get; }
    }
}
