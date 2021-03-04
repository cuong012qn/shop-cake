using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shop_cake.Data;
using shop_cake.Models;
using shop_cake.ViewModel;
using shop_cake.Extensions;

namespace shop_cake.Controllers
{
    //[Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly ShopCakeDBContext _context;
        private readonly IWebHostEnvironment _hosting;

        public ProductController(ShopCakeDBContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        // GET: Product
        [Route("Admin/Product")]
        public async Task<IActionResult> Index()
        {
            var shopCakeDBContext = _context.Products.Include(p => p.TypeProduct);
            return View(await shopCakeDBContext.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.TypeProduct)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        [Route("Admin/Product/Create")]
        public IActionResult Create()
        {
            ViewData["Name"] = new SelectList(_context.TypeProducts, "ID", "Name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, Route("Admin/Product/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product()
                {
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    IDType = productVM.IDType,
                    Image = productVM.ImageUpload.FileName,
                    Name = productVM.Name,
                    Description = productVM.Description,
                    New = productVM.New,
                    PromotionPrice = productVM.PromotionPrice,
                    Unit = productVM.Unit,
                    UnitPrice = productVM.UnitPrice
                };

                await FileUploadHelper.Instance.Upload(productVM.ImageUpload, _hosting);

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Name"] = new SelectList(_context.TypeProducts, "ID", "Name", productVM.IDType);
            return View(productVM);
        }

        // GET: Product/Edit/5
        [Route("Admin/Product/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ProductViewModel productVM = new ProductViewModel()
            {
                ID = product.ID,
                CreateAt = product.CreateAt,
                UpdateAt = product.UpdateAt,
                Image = product.Image,
                Description = product.Description,
                IDType = product.IDType,
                Name = product.Name,
                New = product.New,
                PromotionPrice = product.PromotionPrice,
                UnitPrice = product.UnitPrice,
                Unit = product.Unit
            };

            ViewData["IDType"] = new SelectList(_context.TypeProducts, "ID", "Name", productVM.IDType);
            return View(productVM);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Admin/Product/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var getProduct = _context.Products.SingleOrDefault(x => x.ID.Equals(id));
                if (getProduct != null)
                {
                    //Delete image 
                    FileUploadHelper.Instance.Delete(getProduct.Image, _hosting);
                    try
                    {
                        await FileUploadHelper.Instance.Upload(product.ImageUpload, _hosting);
                        getProduct.Update(
                            product.Name, 
                            product.Description, 
                            product.UnitPrice, 
                            product.PromotionPrice, 
                            product.ImageUpload.FileName, 
                            product.Unit, product.New, 
                            DateTime.Now, product.IDType);

                        _context.Update(getProduct);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductExists(product.ID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDType"] = new SelectList(_context.TypeProducts, "ID", "Description", product.IDType);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.TypeProduct)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
