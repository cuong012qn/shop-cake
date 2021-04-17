using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using shop_cake.Models;
using shop_cake.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop_cake.Areas.Admin.ViewModels
{
    [NotMapped]
    public class OrderViewModel
    {
        //Constructor
        public OrderViewModel()
        {

        }

        [Required]
        public int IDBill { get; set; }

        [Required]
        public Bill Bill { get; set; }

        [Required]
        public IEnumerable<BillDetail> BillDetail { get; set; }

        [Required]
        public Customer Customer { get; set; }
    }
}
