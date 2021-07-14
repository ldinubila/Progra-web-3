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
            return _dbContext.Pedidos.Include("PedidoArticulos").Include("PedidoArticulos.IdArticuloNavigation").Include("IdEstadoNavigation").Include("IdClienteNavigation").Where(a => a.IdPedido == id).FirstOrDefault();
        }

        public Cliente ObtenerClientePorId(int id)
        {
            return _dbContext.Clientes.Find(id);
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

        //Elimina todo el pedido de la vista EditarPedido
        public void Eliminar(int id)
        {
            Pedido pedidoNuevo = _dbContext.Pedidos.Find(id);
            _dbContext.Pedidos.Remove(pedidoNuevo);
            _dbContext.SaveChanges();
        }

        public void EliminarArticuloPedido(Pedido pedido)
        {
            List<PedidoArticulo> pedidoArticulo = _dbContext.PedidoArticulos.Where(p => p.IdPedido == pedido.IdPedido).ToList();
            foreach(PedidoArticulo pedart in pedidoArticulo)
            {
                _dbContext.PedidoArticulos.Remove(pedart);
            }
            _dbContext.SaveChanges();
        }

        public void CambiarEstadoACerrado(int id)
        {
            Pedido pedidoNuevo = _dbContext.Pedidos.Include("IdEstadoNavigation").Where(a => a.IdPedido == id).FirstOrDefault();
            pedidoNuevo.IdEstado = 2;
            _dbContext.Pedidos.Attach(pedidoNuevo);
            _dbContext.SaveChanges();

        }

        public void CambiarEstadoAEntregado(int id)
        {
            Pedido pedidoNuevo = _dbContext.Pedidos.Include("IdEstadoNavigation").Where(a => a.IdPedido == id).FirstOrDefault();
            pedidoNuevo.IdEstado = 3;
            _dbContext.Pedidos.Attach(pedidoNuevo);
            _dbContext.SaveChanges();
        }

        public List<Articulo> ObtenerTodosLosArticulos()
        {
            return _dbContext.Articulos.ToList();
        }
    }
}
