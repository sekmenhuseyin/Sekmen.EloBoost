using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace EloBoost.Web.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel(opt => opt.AddServerHeader = false)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
