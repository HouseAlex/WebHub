using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller}/{action=Index}/{id?}");

//app.MapFallbackToFile("index.html");

//app.Run();

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