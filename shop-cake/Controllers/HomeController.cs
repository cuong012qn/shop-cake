using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shop_cake.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using shop_cake.Data;
using shop_cake.Extensions;
using shop_cake.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace shop_cake.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopCakeDBContext context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ShopCakeDBContext _context)
        {
            _logger = logger;
            context = _context;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> allProducts = context.Products.ToList();
            List<Product> newsproducts = await context.Products.Where(x => x.New.Equals(1)).OrderByDescending(x => x.ID).ToListAsync();
            List<TypeProduct> typeProducts = await context.TypeProducts.ToListAsync();

            List<Product> getCarts = SessionHelper.Get<List<Product>>(HttpContext.Session, "cart");
            ViewData["cart"] = getCarts == null ? new List<Product>() : getCarts;
            ViewData["allproducts"] = allProducts;
            ViewData["TypeProducts"] = typeProducts;
            return View(newsproducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return View(nameof(Index));
            List<Product> getCarts = SessionHelper.Get<List<Product>>(HttpContext.Session, "cart");
            ViewData["cart"] = getCarts == null ? new List<Product>() : getCarts;
            var getNewProduct = await context.Products.Where(x => x.New.Equals(1)).OrderBy(x => x.UnitPrice).Take(4).ToListAsync();
            ViewData["NewProducts"] = getNewProduct;
            var getProduct = await context.Products.SingleOrDefaultAsync(x => x.ID.Equals(id));

            List<TypeProduct> typeProducts = await context.TypeProducts.ToListAsync();
            ViewData["TypeProducts"] = typeProducts;

            return View(getProduct);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
