using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BmstuLibResources.Startup))]
namespace BmstuLibResources
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
