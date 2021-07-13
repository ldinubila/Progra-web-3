using Progra_web_3_Tp_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra_web_3_Tp_final.Servicios
{

    public interface ILoginServicio
    {
       bool Ingresar(string nombre, string password,  out Usuario usuarioSalida);
    }
}