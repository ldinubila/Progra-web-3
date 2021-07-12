using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Progra_web_3_Tp_final.Models;

namespace Progra_web_3_Tp_final.Servicios
{
    interface IPedidosServicio
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
