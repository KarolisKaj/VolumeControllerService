namespace VolumeControllerService.REST
{
    using Owin;
    using System.Web.Http;
    public class StartUpConfig
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            //config.Routes.MapHttpRoute(
            //    name: "Volume",
            //    routeTemplate: "api/{controller}/{id, volume}",
            //    defaults: new { id = RouteParameter.Optional, volume = RouteParameter.Optional }
            //);
            config.Routes.MapHttpRoute(
                name: "Volume",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
