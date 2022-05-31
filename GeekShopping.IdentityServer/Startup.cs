using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.Initializer;
using GeekShopping.IdentityServer.Model;
using GeekShopping.IdentityServer.Model.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["MySQLConnection:MySQLConnectionString"];

            services.AddDbContext<MySqlContext>(options => options.
                UseMySql(connection,
                    new MySqlServerVersion(
                        new Version(8, 0, 28))));

            //Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MySqlContext>()
                .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;
                    options.EmitStaticAudienceClaim = true;
                }).AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
                .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
                .AddInMemoryClients(IdentityConfiguration.Clients)
                .AddAspNetIdentity<ApplicationUser>();

            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddControllersWithViews();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env, IDbInitializer dbInitializer)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer(); //identity
            app.UseAuthorization();

            dbInitializer.Initialize(); //Popula banco de dados a primeira vez com usuario admin e client

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
