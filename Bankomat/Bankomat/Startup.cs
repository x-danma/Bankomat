using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bankomat.Startup))]
namespace Bankomat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
