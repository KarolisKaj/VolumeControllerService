namespace VolumeControllerService.Contracts
{
    using System;
    [Serializable]
    public class VolumeInfoResponse : ResponseBase
    {
        public VolumeInfoResponse(Guid id, int volume) : base(id, volume)
        {
        }
    }
}
