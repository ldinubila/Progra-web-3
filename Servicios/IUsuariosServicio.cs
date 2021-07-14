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
        void Alta(Usuario user,int usuario);
        void ModificarUsuario(Usuario user, int usuario);
        void Eliminar(Usuario user, int usuario);
    }           
}