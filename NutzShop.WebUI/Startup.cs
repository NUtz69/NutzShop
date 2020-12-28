using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NutzShop.WebUI.Startup))]
namespace NutzShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
