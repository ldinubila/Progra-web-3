using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Progra_web_3_Tp_final.Models;
using Progra_web_3_Tp_final.Servicios;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Progra_web_3_Tp_final.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly LoginServicio _loginServicio;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
            _20211CTPContext dbContext = new _20211CTPContext();
            _loginServicio = new LoginServicio(dbContext);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]


        public string Login(string user, string password)
        {
            // Tu código para validar que el usuario ingresado es válido
            _loginServicio.Ingresar(user, password, out Usuario usuarioSalida);
            // Asumamos que tenemos un usuario válido

            // Leemos el secret_key desde nuestro appseting
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            // Creamos los claims (pertenencias, características) del usuario
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, usuarioSalida.Email)
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, usuarioSalida.Email),
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



    }
}
