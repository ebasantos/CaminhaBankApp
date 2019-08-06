using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaminhaBankApp.Startup))]
namespace CaminhaBankApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
