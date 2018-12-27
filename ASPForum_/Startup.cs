using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPForum_.Startup))]
namespace ASPForum_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
