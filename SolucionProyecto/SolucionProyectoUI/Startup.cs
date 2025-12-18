using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SolucionProyectoUI.Startup))]
namespace SolucionProyectoUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
