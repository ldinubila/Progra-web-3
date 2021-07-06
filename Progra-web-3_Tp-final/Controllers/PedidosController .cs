using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Progra_web_3_Tp_final.Servicios;
using Progra_web_3_Tp_final.Models;
using Microsoft.EntityFrameworkCore;

namespace Progra_web_3_Tp_final.Controllers
{
    public class PedidosController : Controller
    {
        _20211CTPContext context;
        private IPedidosServicio _pedidosServicio;

        public PedidosController()
        {
            context = new _20211CTPContext();
            _pedidosServicio = new PedidosServicio(context);
        }

        public IActionResult Index()
        {
            return View(context.Pedidos.Include("IdClienteNavigation").Include("IdEstadoNavigation").ToList());
        }

        public IActionResult NuevoPedido()
        {
            return View();
        }

        public ActionResult EditarPedido(int id)
        {
            Pedido pedido = _pedidosServicio.ObtenerPorId(id);
            return View(pedido);
        }

        [HttpPost]
        public ActionResult EditarPedido(Pedido pedido)
        {
            _pedidosServicio.Modificar(pedido);
            return Redirect("/Pedidos");
        }

        //public ActionResult EditarPedido()
        //{
        //    return View();
        //}

        public IActionResult Eliminar(int id)
        {
            Pedido pedido = _pedidosServicio.ObtenerPorId(id);

            return View();
        }
    }
}
