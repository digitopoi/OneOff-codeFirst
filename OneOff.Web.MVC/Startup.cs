using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OneOff.Web.MVC.Startup))]
namespace OneOff.Web.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
