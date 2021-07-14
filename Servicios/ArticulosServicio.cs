using Entidades.Models;
using System;

namespace Servicios
{
    public class ArticulosServicio : IArticulosServicio
    {
        private _20211CTPContext _dbContext;

        public ArticulosServicio(_20211CTPContext dbContext)
        {
            _dbContext = new _20211CTPContext();
        }

        public Articulo ObtenerPorId(int id)
        {
            return _dbContext.Articulos.Find(id);
        }

        public void Alta(Articulo art, int usuario)
        {
            art.CreadoPor = usuario;
            _dbContext.Articulos.Add(art);
            _dbContext.SaveChanges();
        }

        public void Modificar(Articulo art, int usuario)
        {
            Articulo artNuevo = ObtenerPorId(art.IdArticulo);
            artNuevo.Codigo = art.Codigo;
            artNuevo.Descripcion = art.Descripcion;
            artNuevo.FechaModificacion = DateTime.Now;
            artNuevo.ModificadoPor = usuario;
            _dbContext.SaveChanges();
        }

        public void Eliminar(Articulo art, int usuario)
        {
            art.BorradoPor = usuario;
            _dbContext.Articulos.Remove(art);
            _dbContext.SaveChanges();
        }


    }
}
