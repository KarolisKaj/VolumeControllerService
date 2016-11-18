namespace VolumeControllerService.Services
{
    public interface ILocalVolumeService
    {
        int GetVolumeLevel();
        bool SetVolumeLevel();
        // Maybe event, try to get a change.
    }
}