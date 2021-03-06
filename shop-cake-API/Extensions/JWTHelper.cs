﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using shop_cake_API.Models;

namespace shop_cake_API.Extensions
{
    public class JWTHelper
    {
        public static JwtSecurityToken ValidateJWT(string secretkey, string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretkey);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;
        }

        public static string GenerateJWT(string secretkey, User user, double expires = 60)
        {
            if (string.IsNullOrEmpty(secretkey) || user == null) return string.Empty;
            var symmetricKey = Encoding.UTF8.GetBytes(secretkey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                            new Claim("id", user.ID.ToString()),
                            new Claim(ClaimTypes.Name, user.Username)
                        }),

                Expires = now.AddMinutes(expires),

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
