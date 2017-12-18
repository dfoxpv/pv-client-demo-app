using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MS_Demo_Client.Startup))]
namespace MS_Demo_Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
