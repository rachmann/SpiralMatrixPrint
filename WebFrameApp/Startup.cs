using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFrameApp.Startup))]
namespace WebFrameApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
