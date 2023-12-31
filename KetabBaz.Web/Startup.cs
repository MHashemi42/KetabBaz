using KetabBaz.Web.CustomTokenProviders;
using KetabBaz.Infrastructure.Data.Identity;
using KetabBaz.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using System;
using KetabBaz.Infrastructure.Data.CustomValdiators;
using KetabBaz.Web.Extensions;

namespace KetabBaz.Web;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddControllers();
        services.ConfigureRouteOptions();
        services.ConfigureDbContext(Configuration);
        services.ConfigureIdentity(Configuration);
        services.ConfigureAutoMapper();
        services.ConfigureEmailService(Configuration);
        services.ConfigureEntityRepositories();
        services.ConfigureEntityServices();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();


        app.UseRouting();
        app.UseAuthentication();
        //app.UseLogout();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
        });
    }
}
