using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop_cake.Data;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using shop_cake.Extensions;
using shop_cake.Areas.Admin.ViewModels;

namespace shop_cake.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly ShopCakeDBContext _context;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ShopCakeDBContext context, ILogger<OrderController> logger)
        {
            _context = context;
            _logger = logger;
        }


        // GET: OrderController
        public async Task<ActionResult> Index()
        {
            IQueryable<int> bills = _context.Bills.OrderBy(x => x.DateOrder).Select(x => x.ID);
            List<OrderViewModel> orders = new List<OrderViewModel>();
            foreach (var item in bills)
            {
                orders.Add(await OrderHelper.GetOrder(item, _context));
            }
            return View(orders);
        }

        // GET: OrderController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await OrderHelper.GetOrder(id, _context));
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
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

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirm(int id)
        {
            try
            {
                var findOrder = await _context.Bills.FindAsync(id);
                if (findOrder != null)
                {
                    _context.Bills.Remove(findOrder);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            }
        }
    }
}
