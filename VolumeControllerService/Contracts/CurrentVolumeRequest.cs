namespace VolumeControllerService.Contracts
{
    using System;
    [Serializable]
    public class CurrentVolumeRequest
    {
        public Guid ID { get; set; }
    }
}
