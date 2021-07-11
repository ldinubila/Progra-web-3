using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Logging;
using Progra_web_3_Tp_final.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Progra_web_3_Tp_final.Servicios;
using System.Security.Claims;



namespace Progra_web_3_Tp_final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LoginServicio _loginServicio;
        private readonly TokenServicio _tokenServicio;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _20211CTPContext dbContext = new _20211CTPContext();
            _configuration = config;
            _loginServicio = new LoginServicio(dbContext);
            _tokenServicio = new TokenServicio();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            System.Diagnostics.Debug.WriteLine("Prueba");
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Ingresar()
        {

            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> IngresarAsync(string mail, string pass)
        {
            _loginServicio.Ingresar(mail, pass, out Usuario usuarioSalida);
            if (usuarioSalida != null)
            {
                string tokengenerado = _tokenServicio.generarToken(usuarioSalida, _configuration);
                HttpContext.Session.SetString("Token", tokengenerado);
                var VistaAnteriorSinLogin = HttpContext.Session.GetString("VistaAnteriorSinLogin");

                //var claims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.Name, usuarioSalida.Nombre),
                //    new Claim("username", usuarioSalida.Email),
                //    new Claim(ClaimTypes.NameIdentifier, usuarioSalida.IdUsuario.ToString()),
                //    new Claim(ClaimTypes.Role, usuarioSalida.EsAdmin ? "Admin" : "Usuario")
                //};

                //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                if (VistaAnteriorSinLogin == null)
                    return Redirect("/Pedidos");
                else
                    return Redirect(VistaAnteriorSinLogin);
            }
            else
            {
                TempData["Error"] = "Error. Email o contraseña inválidas";

                return Redirect("/Home");
            }

        }


        public IActionResult Logout()
        {

            HttpContext.SignOutAsync();
            return Redirect("/Login");

        }



    }


}
