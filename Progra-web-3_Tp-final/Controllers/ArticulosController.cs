using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Entidades.Models;
using Servicios;
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
            string returnView = _navegarServicio.ValidarNavegacion(HttpContext.Session.GetString("Token"), HttpContext.Session.GetString("EsAdmin"), _configuration, 'Y', "Articulos");

            if (returnView == "Home")
            {
                HttpContext.Session.SetString("VistaAnteriorSinLogin", "/Articulos/Index");
                return Redirect("/Home");
            }
            if (returnView == "OK")
                return View(context.Articulos.ToList());
            else
            {
                return View(returnView);
            }

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
                _articulosServicio.Alta(art, (int)HttpContext.Session.GetInt32("Usuario"));
                return Redirect("/Articulos/Index");
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
            _articulosServicio.Modificar(art, (int)HttpContext.Session.GetInt32("Usuario"));
            return Redirect("/Articulos/Index");
        }

        public ActionResult Eliminar(int id)
        {
            Articulo art = _articulosServicio.ObtenerPorId(id);
            _articulosServicio.Eliminar(art, (int)HttpContext.Session.GetInt32("Usuario"));
            return Redirect("/Articulos");
        }




    }
}
