namespace VolumeControllerService
{
    using Contracts;
    using Services;
    using System;
    using System.Web.Http;
    public class VolumeController : ApiController
    {
        // Hack but oh well I am not in control of creating this instance.
        public static ILocalVolumeService LocalVolumeService { get; set; }
        // Call: http://localhost/api/volume/0f8fad5b-d9cb-469f-a165-70867728950e/0
        [HttpGet]
        public IHttpActionResult GetVolume(Guid id)
        {
            return Ok(new VolumeResponse { CurrentPCVolume = LocalVolumeService.GetVolumeLevel(), ID = id, IsSuccess = true });
        }

        [HttpGet]
        public IHttpActionResult UpdateVolume(Guid id, int volume)
        {
            LocalVolumeService.SetVolumeLevel(volume);
            var currentVolume = LocalVolumeService.GetVolumeLevel();
            return Ok(new VolumeResponse { CurrentPCVolume = currentVolume, ID = id, IsSuccess = currentVolume == volume });
        }
    }
}
