using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace shop_cake.Models
{
    [Table("BillDetail")]
    public class BillDetail
    {
        public BillDetail()
        {

        }

        public BillDetail(int quantity, double unitPrice, int iDBill, int iDProduct)
        {
            Quantity = quantity;
            UnitPrice = unitPrice;
            IDBill = iDBill;
            IDProduct = iDProduct;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        [Required]
        public int IDBill { get; set; }

        [Required]
        public int IDProduct { get; set; }

        [ForeignKey("IDBill")]
        public Bill Bill { get; set; }

        [ForeignKey("IDProduct")]
        public Product Product { get; set; }
    }
}
