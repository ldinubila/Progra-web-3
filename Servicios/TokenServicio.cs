using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class TokenServicio : ITokenServicio
    {
        private IConfiguration _configuration;
        public string generarToken(Usuario dbUsuario, IConfiguration config)
        {
            _configuration = config;
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, dbUsuario.Nombre),
                    new Claim("username", dbUsuario.Email),
                    new Claim(ClaimTypes.NameIdentifier, dbUsuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, dbUsuario.EsAdmin ? "Admin" : "Usuario")
                        }),
                // Nuestro token va a durar un día
                Expires = DateTime.UtcNow.AddDays(1),
                // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            string bearer_token = tokenHandler.WriteToken(createdToken);

            return bearer_token;
        }

        public bool ValidarTokenId(string key, string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(mySecret),
                    ValidateIssuer = false,
                    ValidateAudience = false
                    // ValidateIssuer = true,
                    //ValidateAudience = true,
                    //ValidIssuer = issuer,
                    //ValidAudience = issuer,
                    //IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }



    }
}