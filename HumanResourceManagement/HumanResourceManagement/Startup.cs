using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HumanResourceManagement.Startup))]
namespace HumanResourceManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
