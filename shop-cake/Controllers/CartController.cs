using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop_cake.Models;
using shop_cake.Data;
using shop_cake.ViewModel;
using shop_cake.Extensions;
using Microsoft.EntityFrameworkCore;
using shop_cake.Areas.Admin.ViewModels;

namespace shop_cake.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopCakeDBContext context;
        public CartController(ShopCakeDBContext shopCakeDBContext)
        {
            context = shopCakeDBContext;
        }


        // GET: CartController
        public async Task<ActionResult> Index()
        {
            List<Product> products = SessionHelper.Get<List<Product>>(HttpContext.Session, "cart");
            List<TypeProduct> typeProducts = await context.TypeProducts.ToListAsync();
            ViewData["TypeProducts"] = typeProducts;
            ViewData["cart"] = products == null ? new List<Product>() : products;
            return View();
        }

        public async Task<IActionResult> Checkout()
        {
            List<Product> products = SessionHelper.Get<List<Product>>(HttpContext.Session, "cart");

            List<TypeProduct> typeProducts = await context.TypeProducts.ToListAsync();
            ViewData["TypeProducts"] = typeProducts;

            //Cart is null cannot redirect to checkout
            if (products == null)
                return StatusCode(404);
            else
            {
                ViewData["cart"] = products;
                return View();
            }
        }


        [HttpPost, ActionName("Checkout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer != null)
                {
                    List<Product> carts = SessionHelper.Get<List<Product>>(HttpContext.Session, "cart");
                    //cart not empty
                    if (carts.Count() > 0)
                    {
                        await OrderHelper.SetOrder(context, carts, customer);
                    }
                    else
                    {
                        return NotFound();
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult RemoveCart(int id, int quantity)
        {
            var find = context.Products.SingleOrDefault(x => x.ID.Equals(id));
            if (find != null)
            {
                List<Product> products = SessionHelper.Get<List<Product>>(HttpContext.Session, "cart");
                int index = isExists(products, id);
                if (index >= 0)
                {
                    if (products[index].Quantity - quantity == 0)
                    {
                        products.RemoveAt(index);
                    }
                    else
                    {
                        products[index].Quantity -= quantity;
                    }
                    SessionHelper.Set<List<Product>>(HttpContext.Session, "cart", products);
                }
                return RedirectToAction(nameof(Index), "Home");
            }
            return StatusCode(404);
        }


        [HttpPost]
        public IActionResult AddCart(int id, int quantity)
        {
            var find = context.Products.SingleOrDefault(x => x.ID.Equals(id));
            if (find != null)
            {
                List<Product> carts = SessionHelper.Get<List<Product>>(HttpContext.Session, "cart");
                if (carts == null) carts = new List<Product>();

                int index = isExists(carts, id);
                if (index >= 0)
                {
                    carts[index].Quantity += quantity;
                }
                else
                {
                    find.Quantity = quantity;
                    carts.Add(find);
                }

                SessionHelper.Set<List<Product>>(HttpContext.Session, "cart", carts);
                return RedirectToAction(nameof(Index), "Home");
            }
            return StatusCode(404);
        }

        /// <summary>
        /// Check item in products
        /// </summary>
        /// <param name="products">List of product</param>
        /// <param name="item">item</param>
        /// <returns>index of item in product, -1 not found</returns>
        private int isExists(List<Product> products, int id)
        {
            return products.FindIndex(x => x.ID.Equals(id));
        }
    }
}
