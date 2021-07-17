using Entidades.Models;
using System;
using Servicios;
using System.Security.Claims;
using System.Linq;

namespace Servicios
{
    public class UsuariosServicio : IUsuariosServicio
    {
        private _20211CTPContext _dbContext;
        private TokenServicio _tokenServicio;
        public UsuariosServicio(_20211CTPContext dbContext)
        {
            _dbContext = new _20211CTPContext();
            _tokenServicio = new TokenServicio();
        }
        public Usuario ObtenerPorId(int id)
        {
            return _dbContext.Usuarios.Find(id);
        }
        public void Alta(Usuario user, int usuario)
        {
            Usuario usuarioEncontrado = _dbContext.Usuarios.FirstOrDefault(o => o.Email == user.Email && o.FechaBorrado == null);

            if (usuarioEncontrado==null)
            {
                user.CreadoPor = usuario;
                _dbContext.Usuarios.Add(user);
                _dbContext.SaveChanges();
            }
            else 
            { 
            }
        }
        public void ModificarUsuario(Usuario user,int usuario)
        {
            Usuario userNuevo = ObtenerPorId(user.IdUsuario);

            Usuario usuarioEncontrado = _dbContext.Usuarios.FirstOrDefault(o => o.Email == user.Email && o.FechaBorrado == null);
            if (usuarioEncontrado == null || usuarioEncontrado.IdUsuario==user.IdUsuario)
            {
                userNuevo.Email = user.Email;
                userNuevo.Password = user.Password;
                userNuevo.EsAdmin = user.EsAdmin;
                userNuevo.Nombre = user.Nombre;
                userNuevo.Apellido = user.Apellido;
                userNuevo.FechaNacimiento = user.FechaNacimiento;
                userNuevo.FechaModificacion = DateTime.Today;
                userNuevo.ModificadoPor = usuario;
                
                _dbContext.SaveChanges();
            }
            
        }
        public void Eliminar(Usuario user,int usuario)
        {
            user.BorradoPor = usuario;
            _dbContext.Usuarios.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
