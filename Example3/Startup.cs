using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Example3.Startup))]
namespace Example3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
