using Microsoft.AspNetCore.Http;
using shop_cake.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace shop_cake.ViewModel
{
    public class ProductViewModel
    {
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        [Range(0, double.MaxValue)]
        public double PromotionPrice { get; set; }

        public string Image { get; set; }

        [Required, MaxLength(255)]
        public string Unit { get; set; }

        [Required]
        public int New { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        [Required,DataType(DataType.Upload)]
        [NotMapped]
        public IFormFile ImageUpload { get; set; }

        [Required]
        public int IDType { get; set; }

        //[ForeignKey("IDType")]
        //public TypeProduct TypeProduct { get; set; }

        //public IList<BillDetail> BillDetails { get; set; }
    }
}
