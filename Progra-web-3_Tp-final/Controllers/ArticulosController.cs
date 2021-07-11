using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Progra_web_3_Tp_final.Models;
using Progra_web_3_Tp_final.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra_web_3_Tp_final.Controllers
{
    [Authorize]
    public class ArticulosController : Controller
    {
        _20211CTPContext context;
        private IArticulosServicio _articulosServicio;
        private readonly TokenServicio _tokenServicio;
        private readonly IConfiguration _configuration;
        private readonly NavegarServicio _navegarServicio;

        public ArticulosController(IConfiguration config)
        {
            context = new _20211CTPContext();
            _articulosServicio = new ArticulosServicio(context);
            _tokenServicio = new TokenServicio();
            _configuration = config;
            _navegarServicio = new NavegarServicio();
        }
        
        [AllowAnonymous]
        public IActionResult Index()
        {
            var secretKey = _configuration.GetValue<string>("SecretKey");
            string returnView = _navegarServicio.ValidarNavegacion(HttpContext.Session.GetString("Token"), HttpContext.Session.GetString("EsAdmin"), _configuration, 'Y', "Articulos");

            if (returnView == "Home")
            {
                HttpContext.Session.SetString("VistaAnteriorSinLogin", "/Usuarios");
                return Redirect("/Home");
            }

            return View(context.Articulos.ToList());
        }
        

        public ActionResult NuevoArticulo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoArticulo(Articulo art)
        {
            if (ModelState.IsValid)
            {
                _articulosServicio.Alta(art);
                return Redirect("/Articulos");
            }
            return View(art);
        }

        public ActionResult EditarArticulo(int id)
        {
            Articulo art = _articulosServicio.ObtenerPorId(id);
            return View(art);
        }

        [HttpPost]
       public ActionResult EditarArticulo(Articulo art)
        {
            _articulosServicio.Modificar(art);
            return Redirect("/Articulos");
        }

        public ActionResult Eliminar(int id)
        {
            Articulo art = _articulosServicio.ObtenerPorId(id);
            _articulosServicio.Eliminar(art);
            return Redirect("/Articulos");
        }




    }
}
