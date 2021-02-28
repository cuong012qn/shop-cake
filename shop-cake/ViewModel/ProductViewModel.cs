using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shop_cake.ViewModel
{
    public class ProductViewModel
    {
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        [Required]
        public double PromotionPrice { get; set; }

        [Required, MaxLength(255)]
        public string Image { get; set; }

        [Required, MaxLength(255)]
        public string Unit { get; set; }

        [Required]
        public int New { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        [Required]
        public int IDType { get; set; }

        //[ForeignKey("IDType")]
        //public TypeProduct TypeProduct { get; set; }

        //public IList<BillDetail> BillDetails { get; set; }
    }
}
