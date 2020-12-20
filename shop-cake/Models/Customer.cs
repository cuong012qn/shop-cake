using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace shop_cake.Models
{
    [Table("Customer")]
    public class Customer
    {
        public Customer()
        {

        }

        public Customer(string name, string gender, string email, string address, string phone, string note)
        {
            Name = name;
            Gender = gender;
            Email = email;
            Address = address;
            Phone = phone;
            Note = note;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(200)]
        public string Note { get; set; }

        public IList<Bill> Bills { get; set; }
    }
}
