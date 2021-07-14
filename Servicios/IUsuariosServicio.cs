using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IUsuariosServicio
    {
        Usuario ObtenerPorId(int id);
        void CrearNuevo(Usuario user);
        void ModificarUsuario(Usuario user);
        void Eliminar(Usuario user);
    }           
}