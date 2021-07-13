using Progra_web_3_Tp_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;




namespace Progra_web_3_Tp_final.Servicios
{
    public class LoginServicio : ILoginServicio
    {
        private _20211CTPContext _dBcontext;

        public LoginServicio(_20211CTPContext dBContext)
        {
            _dBcontext = dBContext;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }


        //public string Ingresar(string mail, string pass)
        //public bool Ingresar(string Email, string Password, out Usuario usuarioEncontrado)
        public bool Ingresar(string Email, string Password, out Usuario usuarioEncontrado)
        {

            //Origen de datos
            //   _20211CTPContext user = new _20211CTPContext();

            //Preparación de 
            //var user = _dBcontext.Usuarios.Include(o => o.Email).Include(o => o.Password).FirstOrDefault();
            usuarioEncontrado = _dBcontext.Usuarios.FirstOrDefault(o => o.Email == Email && o.Password == Password);

            //Ejecución
            //Console.WriteLine("Login:" + login.Count());

            if (usuarioEncontrado != null)
            {
                //return usuarioEncontrado.First().EsAdmin ? "Usuarios" : "Pedidos";   
                return usuarioEncontrado != null;

            }
            return false;
        }
         
    }
}
