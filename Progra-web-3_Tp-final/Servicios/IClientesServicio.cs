using Progra_web_3_Tp_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progra_web_3_Tp_final.Servicios
{
    interface IClientesServicio
    {
        Cliente ObtenerPorId(int id);
        void Alta(Cliente cliente);
        void Modificar(Cliente cliente);
        void Eliminar(Cliente cliente);
    }
}
