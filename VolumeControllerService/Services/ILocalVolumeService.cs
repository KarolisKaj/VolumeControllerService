namespace VolumeControllerService.Services
{
    using AudioSwitcher.AudioApi;
    using System;
    public interface ILocalVolumeService
    {
        int GetVolumeLevel();
        bool SetVolumeLevel(int volume);
        IObservable<DeviceVolumeChangedArgs> VolumeObservable { get; }
    }
}