namespace VolumeControllerService.REST
{
    using Owin;
    using System.Web.Http;

    public class StartUpConfig
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "GetVolume",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "SetVolume",
                routeTemplate: "api/{controller}/{id}/{volume}",
                defaults: new { id = RouteParameter.Optional, volume = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
