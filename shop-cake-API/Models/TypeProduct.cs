using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace shop_cake_API.Models
{
    [Table("TypeProduct")]
    public class TypeProduct
    {
        public TypeProduct()
        {

        }

        public TypeProduct(string name, string description, string image)
        {
            Name = name;
            Description = description;
            Image = image;
        }

        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required,MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        public IList<Product> Products { get; set; }
    }
}
