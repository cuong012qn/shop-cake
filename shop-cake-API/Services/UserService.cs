using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using shop_cake_API.Models;
using shop_cake_API.Services.Interface;

namespace shop_cake_API.Services
{
    public class UserService : IUserService
    {
        private readonly ShopCakeDBContext _context;

        public UserService(ShopCakeDBContext context)
        {
            _context = context;
        }

        public void Authencation(User user)
        {
            if (_context.Users.Any(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password)))
            {

            }
            throw new NotImplementedException();
        }

        public User GetUserByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
