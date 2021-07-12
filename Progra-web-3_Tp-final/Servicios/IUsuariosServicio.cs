using Progra_web_3_Tp_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progra_web_3_Tp_final.Servicios
{
    interface IUsuariosServicio
    {
        Usuario ObtenerPorId(int id);
        void CrearNuevo(Usuario user);
        void ModificarUsuario(Usuario user);
        void Eliminar(Usuario user);
    }           
}