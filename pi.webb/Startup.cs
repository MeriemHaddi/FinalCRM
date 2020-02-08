using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pi.webb.Startup))]
namespace pi.webb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
