namespace VolumeControllerService
{
    using Contracts;
    using System;
    using System.Net.Http;
    using System.Web.Http;
    public class VolumeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetVolume(Guid id)
        {
            return Ok(new VolumeResponse { CurrentPCVolume = 50, ID = id, IsSuccess = true });
        }

        [HttpPost]
        public void UpdateVolume(Guid id, int volume)
        {

        }
    }
}
