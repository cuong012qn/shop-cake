using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using shop_cake_API.Services;
using shop_cake_API.Services.Interface;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shop_cake_API.Extensions;

namespace shop_cake_API.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, userService, token);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var jwtToken = JWTHelper.ValidateJWT(_configuration.GetValue<string>("SecretKey"), token);
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetUserByID(userId);
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}