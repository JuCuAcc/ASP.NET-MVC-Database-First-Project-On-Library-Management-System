using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Library_Mvc_Jashim.Startup))]
namespace Library_Mvc_Jashim
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
