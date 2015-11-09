using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CampusCourier.Startup))]
namespace CampusCourier
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
