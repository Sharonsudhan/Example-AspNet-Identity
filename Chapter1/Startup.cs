using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Chapter1.Startup))]
namespace Chapter1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
