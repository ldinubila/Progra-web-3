using Entidades.Models;
using System;

namespace Servicios
{
    public class ClientesServicio : IClientesServicio
    {
        private _20211CTPContext _dbContext;

        public ClientesServicio(_20211CTPContext dbContext)
        {
            _dbContext = new _20211CTPContext();
        }

        public Cliente ObtenerPorId(int id)
        {
            return _dbContext.Clientes.Find(id);
        }

        public void Alta(Cliente cliente)
        {
            _dbContext.Clientes.Add(cliente);
            _dbContext.SaveChanges();
        }

        public void Modificar(Cliente cliente)
        {
            Cliente clienteNuevo = ObtenerPorId(cliente.IdCliente);
            clienteNuevo.Nombre = cliente.Nombre;
            clienteNuevo.Numero = cliente.Numero;
            clienteNuevo.Telefono = cliente.Telefono;
            clienteNuevo.Direccion = cliente.Direccion;
            clienteNuevo.Email = cliente.Email;
            clienteNuevo.Cuit = cliente.Cuit;
            clienteNuevo.FechaModificacion = DateTime.Now;
            _dbContext.Update(clienteNuevo);
            _dbContext.SaveChanges();
        }

        public void Eliminar(Cliente cliente)
        {
            Console.WriteLine("-------------");
            Console.WriteLine(cliente.IdCliente);
            _dbContext.Clientes.Remove(cliente);
            _dbContext.SaveChanges();
        }


    }
}
