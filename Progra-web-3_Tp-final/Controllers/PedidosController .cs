using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Progra_web_3_Tp_final.Models;
using Progra_web_3_Tp_final.Servicios;
using System.Linq;

namespace Progra_web_3_Tp_final.Controllers
{
    [Authorize]
    public class PedidosController : Controller
    {
        _20211CTPContext context;
        private IPedidosServicio _pedidosServicio;
        private readonly TokenServicio _tokenServicio;
        private readonly IConfiguration _configuration;
        private readonly NavegarServicio _navegarServicio;

        public PedidosController(IConfiguration config)
        {
            context = new _20211CTPContext();
            _pedidosServicio = new PedidosServicio(context);
            _tokenServicio = new TokenServicio();
            _configuration = config;
            _navegarServicio = new NavegarServicio();

        }
        [AllowAnonymous]
        public IActionResult Index()
        {

            string returnView = _navegarServicio.ValidarNavegacion(HttpContext.Session.GetString("Token"), HttpContext.Session.GetString("EsAdmin"), _configuration, 'N', "Pedidos");

            if (returnView == "Home")
            {
                HttpContext.Session.SetString("VistaAnteriorSinLogin", "/Pedidos/Index");
                return Redirect("/Home");
            }
            if (returnView == "OK")
                return View(context.Pedidos.Include("IdClienteNavigation").Include("IdEstadoNavigation").ToList());
            else
            {
                return View(returnView);
            }

        }

        public IActionResult NuevoPedido()
        {
            ViewBag.TodosLosArticulos = _pedidosServicio.ObtenerTodosLosArticulos();
            
            return View(context.Clientes.ToList());
            //return View(context.Pedidos.Include("IdClienteNavigation").Include("IdEstadoNavigation").ToList());
            //ViewBag.TodosClientes = _pedidosServicio.ObtenerTodosClientes();
            //return View();
        }

        public ActionResult EditarPedido(int id)
        {
            Pedido pedido = _pedidosServicio.ObtenerPorId(id);
            ViewBag.TodosLosArticulos = _pedidosServicio.ObtenerTodosLosArticulos();
            return View(pedido);
        }

        [HttpPost]
        public ActionResult EditarPedido(Pedido pedido)
        {
            
            _pedidosServicio.Modificar(pedido);
            return Redirect("/Pedidos/Index");
        }

        //public ActionResult EditarPedido()
        //{
        //    return View();
        //}


        public IActionResult Eliminar(int id)
        {
            //_pedidosServicio.EliminarArticuloPedido(pedido);
            _pedidosServicio.Eliminar(id);
            return Redirect("/Pedidos/Index");
        }

        public IActionResult PedidoCerrado(int id)
        {
            _pedidosServicio.CambiarEstadoACerrado(id);
            return Redirect("/Pedidos/Index");
        }

        public IActionResult PedidoEntregado(int id)
        {
            _pedidosServicio.CambiarEstadoAEntregado(id);
            return Redirect("/Pedidos/Index");
        }

        public IActionResult AgregarPedido(int idCliente, int[] cantidad, int[] articulo,string textarea)
        {
            
            return Redirect("/Index");
        }

        public ActionResult Alta(Pedido pedido)
        {
            _pedidosServicio.Alta(pedido);
            return Redirect("/Pedidos");
        }
    }
}
