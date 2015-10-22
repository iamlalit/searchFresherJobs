using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SearchFresherJobs.Startup))]
namespace SearchFresherJobs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
