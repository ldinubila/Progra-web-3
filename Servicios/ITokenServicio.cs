using Microsoft.Extensions.Configuration;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios
{
    public interface ITokenServicio
    {
        public string generarToken(Usuario dbUsuario, IConfiguration config);
    }
}
