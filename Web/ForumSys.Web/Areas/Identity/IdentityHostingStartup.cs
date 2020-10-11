using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ForumSys.Web.Areas.Identity.IdentityHostingStartup))]

namespace ForumSys.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}