using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcEmpDemo.Startup))]
namespace MvcEmpDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
