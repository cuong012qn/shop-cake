using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductViewModel = shop_cake.Models.Product;

namespace shop_cake.Views.Product.Components.DeleteNow
{
    public class DeleteNowViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ProductViewModel product)
        {
            return View(product);
        }
    }
}
