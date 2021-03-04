using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shop_cake.Areas.Identity.Data;
using shop_cake.Models;
using shop_cake.ViewModel;

namespace shop_cake.Data
{
    public class ShopCakeDBContext : IdentityDbContext<User>
    {
        public ShopCakeDBContext(DbContextOptions<ShopCakeDBContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }
        public DbSet<shop_cake.ViewModel.ProductViewModel> ProductViewModel { get; set; }
    }
}
