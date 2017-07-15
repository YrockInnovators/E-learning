using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pacesetter.Startup))]
namespace pacesetter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
