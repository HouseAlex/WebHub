using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;


namespace WebHub.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        public Startup(IWebHostEnvironment webHost)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(webHost.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
            Environment = webHost;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddHttpContextAccessor();

            var mvcPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

            services.AddControllers().AddMvcOptions(options =>
            {
                options.CacheProfiles.Add("Never", new CacheProfile
                {
                    Location = ResponseCacheLocation.None,
                    NoStore = true
                });
                options.Filters.Add(new AuthorizeFilter(mvcPolicy));
            });
            services.AddMvc();

            services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}"));

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
                {
                    OnPrepareResponse = (ctx) =>
                    {
                        var headers = ctx.Context.Response.GetTypedHeaders();
                        headers.CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue
                        {
                            NoCache = true,
                            NoStore = true,
                            MustRevalidate = true,
                        };
                    }
                };

                spa.UseAngularCliServer(npmScript: "start");
            });
        }
    }
}
