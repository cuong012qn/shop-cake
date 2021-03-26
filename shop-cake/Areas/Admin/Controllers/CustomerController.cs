using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop_cake.Data;
using Microsoft.EntityFrameworkCore;
using shop_cake.Extensions;
using shop_cake.Models;
using Microsoft.Extensions.Logging;

namespace shop_cake.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly ShopCakeDBContext _context;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ShopCakeDBContext context, ILogger<CustomerController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: CustomerController
        public async Task<ActionResult> Index(int? pageNumber)
        {
            return View(await PaginatedList<Customer>.CreateAsync(_context.Customers, pageNumber ?? 1, 10));
        }

        // GET: CustomerController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _context.Customers.FindAsync(id));
        }

        // GET: CustomerController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Customer customer)
        {
            try
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return View(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Customer customer = await _context.Customers.FindAsync(id);
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Customer customer)
        {
            try
            {
                Customer findCustomer = await _context.Customers.FindAsync(id);
                if (findCustomer != null)
                {
                    findCustomer.Update(customer);
                    _context.Customers.Update(findCustomer);
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

        // GET: CustomerController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _context.Customers.FindAsync(id));
        }

        // POST: CustomerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteComfirm(int id)
        {
            try
            {
                Customer customer = await _context.Customers.FindAsync(id);
                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(nameof(Index));
            }
        }
    }
}
