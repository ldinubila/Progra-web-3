using Microsoft.Extensions.Configuration;
using Progra_web_3_Tp_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra_web_3_Tp_final.Servicios
{
    interface ITokenServicio
    {
        public string generarToken(Usuario dbUsuario, IConfiguration config);
    }
}
