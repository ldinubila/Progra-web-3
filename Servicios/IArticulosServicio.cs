using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IArticulosServicio
    {
        Articulo ObtenerPorId(int id);
        void Alta(Articulo art);
        void Modificar(Articulo art);
        void Eliminar(Articulo art);
    }
}
