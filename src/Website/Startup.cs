using CrateSample.Application;
using CrateSample.Infrastructure;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Website;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected IConfiguration Configuration { get; }

    public void Configure(IApplicationBuilder application, IWebHostEnvironment environment)
    {
        if (!environment.IsDevelopment())
        {
            application.UseExceptionHandler("/Home/Error");
        }

        application.UseStaticFiles();
        application.UseRouting();
        application.UseAuthorization();

        application.UseEndpoints
        (
            builder =>
            {
                builder.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            }
        );
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddApplication();
        services.AddInfrastructure();
    }
}