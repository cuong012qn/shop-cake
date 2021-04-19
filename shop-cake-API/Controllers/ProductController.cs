using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop_cake_API.Models;
using Microsoft.EntityFrameworkCore;

namespace shop_cake_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ShopCakeDBContext _context;
        public ProductController(ShopCakeDBContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Products.ToListAsync());
            //return CreatedAtAction("Get", await _context.Products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return CreatedAtAction("Get", await _context.Products.FindAsync(id));
        }

    }
}
