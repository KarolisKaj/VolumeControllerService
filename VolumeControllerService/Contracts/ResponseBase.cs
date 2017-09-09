namespace VolumeControllerService.Contracts
{
    using System;
    [Serializable]
    public abstract class ResponseBase
    {
        public ResponseBase(Guid id, int volume)
        {
            ID = id;
            Volume = volume;
        }
        public Guid ID { get; }
        public int Volume { get; }
        public string MachinesName { get; } = Environment.MachineName;
    }
}
