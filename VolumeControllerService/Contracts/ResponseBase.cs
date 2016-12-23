namespace VolumeControllerService.Contracts
{
    using System;
    [Serializable]
    public abstract class ResponseBase
    {
        public Guid ID { get; set; }
        public int Volume { get; set; }
        public string MachinesName { get; } = Environment.MachineName;
    }
}
