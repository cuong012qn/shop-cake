using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shop_cake.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using shop_cake.Data;

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

        public IActionResult Index()
        {
            List<Product> allProducts = context.Products.ToList();
            List<Product> newsproducts = context.Products.Where(x => x.New.Equals(1)).ToList();

            ViewData["allproducts"] = allProducts;
            return View(newsproducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Detail(int? id)
        {
            if (id == null) return View(nameof(Index));

            var getProduct = context.Products.SingleOrDefault(x => x.ID.Equals(id));

            return View(getProduct);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
