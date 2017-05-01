using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeList.Web.Startup))]
namespace EmployeeList.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
