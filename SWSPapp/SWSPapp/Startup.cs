using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(startupType: typeof(SWSPapp.Startup))]

namespace SWSPapp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
