using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaminhaBankWebApp.Startup))]
namespace CaminhaBankWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
