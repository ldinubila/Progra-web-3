using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Progra_web_3_Tp_final.Models;

namespace Progra_web_3_Tp_final.Servicios
{
    public class PedidosServicio : IPedidosServicio
    {
        private _20211CTPContext _dbContext;

        public PedidosServicio(_20211CTPContext dbContext)
        {
            _dbContext = new _20211CTPContext();
        }

        public Pedido ObtenerPorId(int id)
        {
            return _dbContext.Pedidos.Include("PedidoArticulos").Include("PedidoArticulos.IdArticuloNavigation").Where(a => a.IdPedido == id).FirstOrDefault();
        }

        public void Alta(Pedido pedido)
        {
            _dbContext.Pedidos.Add(pedido);
            _dbContext.SaveChanges();
        }

        public void Modificar(Pedido pedido)
        {
            Pedido pedidoNuevo = ObtenerPorId(pedido.IdPedido);
            pedidoNuevo.IdPedido = pedido.IdPedido;
            pedidoNuevo.NroPedido = pedido.NroPedido;
            pedidoNuevo.IdCliente = pedido.IdCliente;
            _dbContext.SaveChanges();
        }

        //public void Eliminar(Pedido pedido)
        //{
        //    _dbContext.Articulos.Remove(pedido);
        //    _dbContext.SaveChanges();
        //}
    }
}
