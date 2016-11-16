namespace VolumeControllerService.Contracts
{
    using System;
    [Serializable]
    public class VolumeRequest
    {
        public int Volume { get; set; }
        public Guid ID { get; set; }
    }
}
