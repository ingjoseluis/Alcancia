using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Alcancia.Startup))]
namespace Alcancia
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
