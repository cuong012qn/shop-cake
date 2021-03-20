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
        public ActionResult Index()
        {
            List<Product> products = SessionHelper.Get<List<Product>>(HttpContext.Session, "cart");
            ViewData["cart"] = products == null ? new List<Product>() : products;
            return View();
        }

        public IActionResult Checkout()
        {
            List<Product> products = SessionHelper.Get<List<Product>>(HttpContext.Session, "cart");

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
                        //Create customer
                        context.Customers.Add(customer);

                        //Save customer
                        await context.SaveChangesAsync();

                        //Sum total of carts
                        double total = carts.Sum(x => x.Quantity * x.PromotionPrice != 0 ? x.PromotionPrice : x.UnitPrice);

                        //Create bill
                        Bill bill = new Bill(DateTime.Now, total, "momo", customer.Note, customer.ID);

                        //Save bill
                        context.Bills.Add(bill);

                        await context.SaveChangesAsync();

                        List<BillDetail> billDetails = new List<BillDetail>();

                        for (int i = 0; i < carts.Count(); ++i)
                        {
                            billDetails.Add(new BillDetail()
                            {
                                Quantity = carts[i].Quantity,
                                IDProduct = carts[i].ID,
                                UnitPrice = carts[i].PromotionPrice != 0 ? carts[i].PromotionPrice : carts[i].UnitPrice,
                                IDBill = bill.ID
                            });
                        }

                        context.BillDetails.AddRange(billDetails);

                        await context.SaveChangesAsync();
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

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
