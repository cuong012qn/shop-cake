using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using shop_cake.Areas.Identity.Data;
using shop_cake.Data;
using System;

namespace shop_cake
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ShopCakeDBContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ShopCakeDBContextConnection")));

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ShopCakeDBContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddDistributedMemoryCache();

            services.AddSession(configure =>
            {
                configure.IdleTimeout = TimeSpan.FromMinutes(10);
                configure.Cookie.HttpOnly = true;
                configure.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "MyAreaAdmin", 
                    areaName: "Admin", 
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                      name: "Admin",
                      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                      );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //localhost/admin/product
                //endpoints.MapControllerRoute(name: "product", pattern: "admin/product/{controller=Product}/{action=Index}");

                endpoints.MapRazorPages();
            });

        }
    }
}
