using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeManager.Web.Startup))]
namespace HomeManager.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
