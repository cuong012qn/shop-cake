using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop_cake.Data;
using shop_cake.Extensions;
using shop_cake.Models;
using Microsoft.EntityFrameworkCore;

namespace shop_cake.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly ShopCakeDBContext _context;

        public ProductTypeController(ShopCakeDBContext context)
        {
            _context = context;
        }

        // GET: ProductTypeController
        public async Task<ActionResult> Index(int? id, int? pageNumber)
        {
            //TypeProducts 
            ViewData["TypeProducts"] = await _context.TypeProducts.ToListAsync();

            //Get all
            if (id == null)
            {
                return View(await PaginatedList<Product>.CreateAsync(_context.Products, pageNumber ?? 1, 10));
            }

            IQueryable<Product> products = _context.Products
                .Include(x => x.TypeProduct)
                .Where(x => x.TypeProduct.ID.Equals(id));

            ViewData["TotalProducts"] = products.Count();

            return View(await PaginatedList<Product>.CreateAsync(products, pageNumber ?? 1, 10));
        }

        // GET: ProductTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductTypeController/Create
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

        // GET: ProductTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductTypeController/Edit/5
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

        // GET: ProductTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductTypeController/Delete/5
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
    }
}
