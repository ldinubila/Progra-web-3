using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IClientesServicio
    {
        Cliente ObtenerPorId(int id);
        void Alta(Cliente cliente);
        void Modificar(Cliente cliente);
        void Eliminar(Cliente cliente);
    }
}
