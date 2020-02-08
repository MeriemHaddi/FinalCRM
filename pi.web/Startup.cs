using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pi.web.Startup))]
namespace pi.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
