using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TimeTable.Bootstrap;
using TimeTable.Migration;
using TimeTableHost.ExceptionHandling;

namespace TimeTableHost
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public HostConfig HostConfig { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllersWithViews();

            services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
                });

            HostConfig = new HostConfig();
            Configuration.Bind("HostConfig", HostConfig);
            services.AddSingleton(HostConfig);

            services.AddFluentMigrator(HostConfig.DBConnection, typeof(_0001_Calendar).Assembly);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddModule(HostConfig.DBConnection, "./nlog.config");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.ApplicationServices.GetAutofacRoot().RunMigration();
            app.ConfigGravityExceptionMiddleware(ExceptionsResource.ResourceManager);

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
