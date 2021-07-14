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
    }
}
