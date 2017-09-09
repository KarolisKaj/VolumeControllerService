namespace VolumeControllerService.Contracts
{
    using System;
    [Serializable]
    public class VolumeUpdateResponse : ResponseBase
    {
        public VolumeUpdateResponse(Guid id, int volume, bool isSuccess) : base(id, volume)
        {
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; set; }
    }
}
