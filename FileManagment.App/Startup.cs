using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FileManagment.App.Startup))]
namespace FileManagment.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
