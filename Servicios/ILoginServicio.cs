using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios
{

    public interface ILoginServicio
    {
       bool Ingresar(string nombre, string password,  out Usuario usuarioSalida);
    }
}