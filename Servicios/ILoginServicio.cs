using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios
{

    public interface ILoginServicio
    {

        bool Ingresar(String mail, String pass, out Usuario usuarioSalida);
        public void LogOut(string UsSession);


    }
}