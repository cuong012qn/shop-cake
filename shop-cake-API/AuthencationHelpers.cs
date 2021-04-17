using Microsoft.IdentityModel.Tokens;
using shop_cake_API.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace shop_cake_API
{
    public class AuthencationHelpers
    {
        public static string GenerateJWTToken(string secretkey, User user, double exp = 20)
        {
            var symmetricKey = Encoding.UTF8.GetBytes(secretkey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, user.Username)
                        }),

                Expires = now.AddMinutes(Convert.ToInt32(exp)),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);

            //var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature);

            //var token = new JwtSecurityToken(null, null, null, DateTime.Now, DateTime.Now.AddMinutes(60), signingCredentials);

            //return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
