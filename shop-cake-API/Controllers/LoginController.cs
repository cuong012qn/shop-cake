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
        private readonly IConfiguration configuration;
        private readonly IUserService _userService;

        public LoginController(IConfiguration configuration, IUserService userService)
        {
            this.configuration = configuration;
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetData()
        {
            return Ok(new { success = true });
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
