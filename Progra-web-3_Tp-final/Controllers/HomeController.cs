using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Progra_web_3_Tp_final.Models;
using Progra_web_3_Tp_final.Servicios;
using System.Diagnostics;



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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Privacy()
        {
            System.Diagnostics.Debug.WriteLine("Prueba");
            return View();
        }

        public IActionResult Ingresar()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Ingresar(string mail, string pass)
        {
            _loginServicio.Ingresar(mail, pass, out Usuario usuarioSalida);
            if (usuarioSalida != null)
            {
                string tokengenerado = _tokenServicio.generarToken(usuarioSalida, _configuration);
                HttpContext.Session.SetString("Token", tokengenerado);
                var VistaAnteriorSinLogin = HttpContext.Session.GetString("VistaAnteriorSinLogin");
                HttpContext.Session.SetString("EsAdmin", usuarioSalida.EsAdmin ? "Admin" : "Usuario");

                if (VistaAnteriorSinLogin == null)
                    return Redirect("/Pedidos/Index");
                else
                    return Redirect(VistaAnteriorSinLogin);
            }
            else
            {
                TempData["Error"] = "Error. Email o contraseña inválidas";

                return Redirect("/Home");
            }

        }


        public IActionResult Salir()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }


    }


}
