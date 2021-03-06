using GeekShopping.Web.Services;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;

namespace GeekShopping.Web
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
            services.AddHttpClient<IProductService, ProductService>(c =>
                    c.BaseAddress = new Uri(Configuration["ServicesUrls:ProductAPI"]) //appsettings
            );

            services.AddHttpClient<ICartService, CartService>(c =>
                    c.BaseAddress = new Uri(Configuration["ServicesUrls:CartAPI"]) //appsettings
            );

            services.AddHttpClient<ICouponService, CouponService>(c =>
                    c.BaseAddress = new Uri(Configuration["ServicesUrls:CouponAPI"]) //appsettings
            );

            services.AddControllersWithViews();

            //Config do Token com Identity server utilizando duende
            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
                .AddOpenIdConnect("oidc", options =>
                    {
                        options.Authority = Configuration["ServicesUrls:IdentityServer"]; //appsettings
                        options.GetClaimsFromUserInfoEndpoint = true;
                        options.ClientId = "geek_shopping";
                        options.ClientSecret = "my_super_secret";
                        options.ResponseType = "code";
                        options.ClaimActions.MapJsonKey("role", "role", "role");
                        options.ClaimActions.MapJsonKey("sub", "sub", "sub");
                        options.TokenValidationParameters.NameClaimType = "name";
                        options.TokenValidationParameters.RoleClaimType = "role";
                        options.Scope.Add("geek_shopping");
                        options.SaveTokens = true;
                    }
                );
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
