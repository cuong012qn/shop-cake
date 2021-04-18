using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using shop_cake_API.Models;
using shop_cake_API.Services.Interface;
using shop_cake_API.Extensions;
using Microsoft.Extensions.Configuration;

namespace shop_cake_API.Services
{
    public class UserService : IUserService
    {
        private readonly ShopCakeDBContext _context;
        private readonly IConfiguration _configuration;

        public UserService(ShopCakeDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public User Authencation(User user)
        {
            var findUser = _context.Users.SingleOrDefault(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password));

            if (findUser != null)
            {
                findUser.Token = JWTHelper.GenerateJWT(_configuration.GetValue<string>("SecretKey"), findUser);
                return findUser;
            }
            return null;
        }

        public User GetUserByID(int id)
        {
            return _context.Users.SingleOrDefault(x => x.ID.Equals(id));
        }
    }
}
