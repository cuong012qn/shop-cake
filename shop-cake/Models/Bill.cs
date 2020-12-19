using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace shop_cake.Models
{
    [Table("Bills")]
    public class Bill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ID { get; set; }

        [DataType(DataType.Date), Required]
        public DateTime DateOrder { get; set; }

        [Required]
        public double Total { get; set; }

        [Required]
        [MaxLength(200)]
        public string Payment { get; set; }

        [MaxLength(500)]
        public string Note { get; set; }

        [Required]
        public int IDCustomer { get; set; }

        [ForeignKey("IDCustomer")]
        public Customer Customer { get; set; }

        public IList<BillDetail> BillDetails { get; set; }
    }
}
