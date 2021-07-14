using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Entidades.Models;
using Servicios;
using System.Linq;


namespace Progra_web_3_Tp_final.Controllers
{
    
    [Authorize]
    public class UsuariosController : Controller
    {
        _20211CTPContext context;
        private IUsuariosServicio _usuariosServicio;
        private readonly TokenServicio _tokenServicio;
        private readonly IConfiguration _configuration;
        private readonly NavegarServicio _navegarServicio;

        public UsuariosController(IConfiguration config)
        {
            context = new _20211CTPContext();
            _usuariosServicio = new UsuariosServicio(context);  
            _tokenServicio = new TokenServicio();
            _configuration = config;
            _navegarServicio = new NavegarServicio();
          
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var secretKey = _configuration.GetValue<string>("SecretKey");
            string returnView = _navegarServicio.ValidarNavegacion(HttpContext.Session.GetString("Token"), HttpContext.Session.GetString("EsAdmin"), _configuration, 'Y', "Usuarios");
            
            if(returnView=="Home")
            {
                HttpContext.Session.SetString("VistaAnteriorSinLogin", "/Usuarios/Index");
                return Redirect("/Home");
            }
            if(returnView == "OK")
                return View(context.Usuarios.ToList());
            else
            {
                return View(returnView);
            }
        }

        public IActionResult NuevoUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearNuevo(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
            
                _usuariosServicio.CrearNuevo(usuario);

                return RedirectToAction("Index");

            }
            return Redirect("/Usuarios/Index");
        }
        public IActionResult EditarUsuario(int id)
        {
            Usuario user = _usuariosServicio.ObtenerPorId(id);
            return View(user); 
        }
       
        [HttpPost]
        public ActionResult EditarUsuario(Usuario user)
          {
              _usuariosServicio.ModificarUsuario(user);
              return Redirect("/Usuarios/Index");
          }
        public ActionResult Eliminar(int id)
        {
            Usuario user = _usuariosServicio.ObtenerPorId(id);
            _usuariosServicio.Eliminar(user);
            return Redirect("/Usuarios/Index");
        }

    }
}
