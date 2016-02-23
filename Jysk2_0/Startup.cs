using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jysk2_0.Startup))]
namespace Jysk2_0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
