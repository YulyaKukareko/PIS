using Lab_APSNETCORE.Context;
using Lab_APSNETCORE.Controllers;
using Lab_APSNETCORE.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;

namespace Lab_APSNETCORE
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connectionString = Configuration.GetConnectionString("Database");
            services.AddDbContext<ProjectContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<UsersService>();
            services.AddScoped<ProjectContext>();
            services.AddScoped<ForScoped>();
            services.AddSingleton<ForSingleton>();
            services.AddSingleton<ForSingletonInject>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseBrowserLink();
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Home/Error");

            #region TASK09-10

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("X-KYA", DateTime.Now.ToString("dd.MM.yyyy"));
                }
            }); // For the wwwroot folder

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "html")),
                RequestPath = "/pages",
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("X-KYA", DateTime.Now.ToString("dd.MM.yyyy"));
                }
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "html")),
                RequestPath = "/pages"
            });

            #endregion

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
