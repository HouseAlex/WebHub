using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WebHub.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Builder(args).Build().Run();
        }

        public static IWebHostBuilder Builder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
        }
    }
}