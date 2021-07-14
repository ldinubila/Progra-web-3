using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.Models;

namespace Servicios
{
    public interface IPedidosServicio
    {
        Pedido ObtenerPorId(int id);
        void Alta(Pedido pedido);
        void Modificar(Pedido pedido);

        void Eliminar(int id);

        void EliminarArticuloPedido(Pedido pedido);

        void CambiarEstadoACerrado(int id);

        void CambiarEstadoAEntregado(int id);

        List<Articulo> ObtenerTodosLosArticulos();

        PedidoArticulo CrearPedidoArticulo(int cantidad,int articulo);

        Pedido CrearPedido(List<PedidoArticulo> pedidoArticulo,int idCliente,string textarea);

        Pedido EditarPedido(int IdPedido,List<PedidoArticulo> pedidoArticulo, string textarea);
    }
}
