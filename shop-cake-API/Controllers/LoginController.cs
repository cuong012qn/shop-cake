using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop_cake_API.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace shop_cake_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IConfiguration configuration;

        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
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
            IActionResult response = Unauthorized();
            if (user.Username.Equals("hi") && user.Password.Equals("hi"))
            {
                response = Ok(new
                {
                    token = AuthencationHelpers.GenerateJWTToken(configuration.GetValue<string>("SecretKey"),
                    new User()
                    {
                        Username = "hi",
                        Password = "Hi"
                    }, 60)
                });
            }
            return response;
        }
    }
}
