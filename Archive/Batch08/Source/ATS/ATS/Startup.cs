using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ATS.Startup))]
namespace ATS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
