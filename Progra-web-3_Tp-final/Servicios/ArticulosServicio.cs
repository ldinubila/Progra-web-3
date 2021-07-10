using Progra_web_3_Tp_final.Models;
using System;

namespace Progra_web_3_Tp_final.Servicios
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

        public void Alta(Articulo art)
        {
            _dbContext.Articulos.Add(art);
            _dbContext.SaveChanges();
        }

        public void Modificar(Articulo art)
        {
            Articulo artNuevo = ObtenerPorId(art.IdArticulo);
            artNuevo.Codigo = art.Codigo;
            artNuevo.Descripcion = art.Descripcion;
            artNuevo.FechaModificacion = DateTime.Now;
            _dbContext.SaveChanges();
        }

        public void Eliminar(Articulo art)
        {
            _dbContext.Articulos.Remove(art);
            _dbContext.SaveChanges();
        }


    }
}
