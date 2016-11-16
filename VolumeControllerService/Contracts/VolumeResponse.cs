namespace VolumeControllerService.Contracts
{
    using System;
    [Serializable]
    public class VolumeResponse
    {
        public int CurrentPCVolume { get; set; }
        public Guid ID { get; set; }
        public bool IsSuccess { get; set; }
    }
}
