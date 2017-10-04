using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Betgo.Startup))]
namespace Betgo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
