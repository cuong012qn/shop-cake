using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using shop_cake_API.Models;
using Microsoft.AspNetCore.Authorization;
using shop_cake_API.Services.Interface;

namespace shop_cake_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            var us = _userService.Authencation(user);

            if (us == null) return Unauthorized();


            return Ok(new { token = us.Token });
        }
    }
}
