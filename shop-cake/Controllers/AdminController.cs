using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_cake.Controllers
{
    //[Authorize]
    public class AdminController : Controller
    {
        [Route("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        //[Route("Admin/Products")]
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
