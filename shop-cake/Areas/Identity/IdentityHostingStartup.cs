using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using shop_cake.Areas.Identity.Data;
using shop_cake.Data;

[assembly: HostingStartup(typeof(shop_cake.Areas.Identity.IdentityHostingStartup))]
namespace shop_cake.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<ShopCakeDBContext>(options =>
                    options.UseSqlServer(connectionString: @"Server=DESKTOP-7UOK1F3;Database=shop-cake;Trusted_Connection=True;MultipleActiveResultSets=true"));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<ShopCakeDBContext>();
            });
        }
    }
}