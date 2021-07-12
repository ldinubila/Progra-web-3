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
            ViewBag.TodosLosArticulos = _pedidosServicio.ObtenerTodosLosArticulos();
            
            return View(context.Clientes.ToList());
            //return View(context.Pedidos.Include("IdClienteNavigation").Include("IdEstadoNavigation").ToList());
            //ViewBag.TodosClientes = _pedidosServicio.ObtenerTodosClientes();
            //return View();
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
            //_pedidosServicio.EliminarArticuloPedido(pedido);
            _pedidosServicio.Eliminar(id);
            return Redirect("/Pedidos");
        }

        public IActionResult PedidoCerrado(int id)
        {
            _pedidosServicio.CambiarEstadoACerrado(id);
            return Redirect("/Pedidos");
        }

        public IActionResult PedidoEntregado(int id)
        {
            _pedidosServicio.CambiarEstadoAEntregado(id);
            return Redirect("/Pedidos");
        }

        //public IActionResult AgregarPedido(PedidoArticulo pedart,int cant)
        //{
        //    if(pedart.IdArticuloNavigation.Descripcion)
        //    {
        //        pedart.Cantidad += cant;
        //    }
        //    return Redirect("/EditarPedido");
        //}

    }
}
