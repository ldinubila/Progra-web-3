using Microsoft.AspNetCore.Mvc;
using Progra_web_3_Tp_final.Models;
using Progra_web_3_Tp_final.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra_web_3_Tp_final.Controllers
{
    public class ClientesController : Controller
    {
        _20211CTPContext context;
        private IClientesServicio _clienteServicio;

        public ClientesController()
        {
            context = new _20211CTPContext();
            _clienteServicio = new ClientesServicio(context);
        }

        public IActionResult Index()
        {
            return View(context.Clientes.ToList());
        }

        public ActionResult NuevoCliente()
        {
            return View();
        }

        public ActionResult EditarCliente(int id)
        {
            return View(_clienteServicio.ObtenerPorId(id));
        }

        public IActionResult Alta(Cliente data)
        {
            if (ModelState.IsValid)
            {
                _clienteServicio.Alta(data);

                return Redirect("/Clientes");

            }

            return View("NuevoCliente", data);
        }

        [HttpPost]
        public ActionResult EditarCliente(Cliente data)
        {
            if (ModelState.IsValid)
            {
                _clienteServicio.Modificar(data);

                return Redirect("/Clientes");

            }

            return View("EditarCliente", data);
        }

        public StatusCodeResult Eliminar(int id) {
            Cliente cliente = _clienteServicio.ObtenerPorId(id);
            _clienteServicio.Eliminar(cliente);

            return Ok();
        }

        public Boolean ExisteNumero(int numero)
        {
            return context.Clientes.Where(c => c.Numero == numero).Count() > 0;
        }
    }
}
