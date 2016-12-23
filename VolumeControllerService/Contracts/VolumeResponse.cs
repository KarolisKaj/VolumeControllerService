namespace VolumeControllerService.Contracts
{
    using System;
    [Serializable]
    public class VolumeUpdateResponse : ResponseBase
    {
        public bool IsSuccess { get; set; }
    }
}
