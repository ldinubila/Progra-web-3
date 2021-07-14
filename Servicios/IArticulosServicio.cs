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
        void Alta(Articulo art, int usuario);
        void Modificar(Articulo art, int usuario);
        void Eliminar(Articulo art, int usuario);
    }
}
