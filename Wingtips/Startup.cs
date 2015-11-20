using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wingtips.Startup))]
namespace Wingtips
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
