namespace VolumeControllerService
{
    using Contracts;
    using Services;
    using System;
    using System.Web.Http;
    public class VolumeController : ApiController
    {
        // Hack but oh well creating new IoC just for this does not seem to be worth.
        public static ILocalVolumeService LocalVolumeService { get; set; }
        // Call: http://192.168.0.103:63714/api/volume/0f8fad5b-d9cb-469f-a165-70867728950e/50
        [HttpGet]
        public IHttpActionResult GetVolume(Guid id)
        {
            return Ok(new VolumeUpdateResponse { Volume = LocalVolumeService.GetVolumeLevel(), ID = id, IsSuccess = true });
        }

        [HttpGet]
        public IHttpActionResult UpdateVolume(Guid id, int volume)
        {
            LocalVolumeService.SetVolumeLevel(volume);
            var currentVolume = LocalVolumeService.GetVolumeLevel();
            return Ok(new VolumeUpdateResponse { Volume = currentVolume, ID = id, IsSuccess = currentVolume == volume });
        }
    }
}
