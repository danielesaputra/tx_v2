using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TukangXpress_v2.Startup))]
namespace TukangXpress_v2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
