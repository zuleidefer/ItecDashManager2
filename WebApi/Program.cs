using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ItecDashManager.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                string port = Environment.GetEnvironmentVariable("PORT") ?? "5001";
                string url = $"http://*:{port}";

                webBuilder.UseStartup<Startup>();
                webBuilder.UseUrls(url);
            });
}
