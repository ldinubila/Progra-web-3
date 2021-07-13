﻿using Progra_web_3_Tp_final.Models;
using System;
using System.Linq;

namespace Progra_web_3_Tp_final.Servicios
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
        public void Alta(Usuario user)
        {
            Usuario usuarioEncontrado = _dbContext.Usuarios.FirstOrDefault(o => o.Email == user.Email && o.FechaBorrado == null);

            if (usuarioEncontrado==null)
            {
                _dbContext.Usuarios.Add(user);
                _dbContext.SaveChanges();
            }
            else 
            { 
            }
        }
        public void ModificarUsuario(Usuario user)
        {
            Usuario userNuevo = ObtenerPorId(user.IdUsuario);

            Usuario usuarioEncontrado = _dbContext.Usuarios.FirstOrDefault(o => o.Email == user.Email && o.FechaBorrado == null);
            if (usuarioEncontrado == null)
            {
                userNuevo.Email = user.Email;
                userNuevo.Password = user.Password;
                userNuevo.EsAdmin = user.EsAdmin;
                userNuevo.Nombre = user.Nombre;
                userNuevo.Apellido = user.Apellido;
                userNuevo.FechaNacimiento = user.FechaNacimiento;
                userNuevo.FechaModificacion = DateTime.Now;
                userNuevo.ModificadoPor=
                _dbContext.SaveChanges();
            }
        }
        public void Eliminar(Usuario user)
        {
            _dbContext.Usuarios.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
