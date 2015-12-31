using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gathering.Startup))]
namespace Gathering
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
