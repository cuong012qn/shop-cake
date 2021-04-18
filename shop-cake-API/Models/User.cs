using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace shop_cake_API.Models
{
    public class User
    {
        public User(int iD, string username, string password, string token)
        {
            ID = iD;
            Username = username;
            Password = password;
            Token = token;
        }

        public User()
        {

        }

        [Key]
        public int ID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}
