using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop_cake_API.Models;

namespace shop_cake_API.Services.Interface
{
    public interface IUserService
    {
        User Authencation(User user);

        User GetUserByID(int id);
    }
}
