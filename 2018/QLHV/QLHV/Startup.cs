using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLHV.Startup))]
namespace QLHV
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
