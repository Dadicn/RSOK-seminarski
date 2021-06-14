using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EvidencijaAvioKarata.Startup))]
namespace EvidencijaAvioKarata
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
