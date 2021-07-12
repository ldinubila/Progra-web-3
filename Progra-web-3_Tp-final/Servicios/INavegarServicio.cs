using System;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra_web_3_Tp_final.Servicios
{
    interface INavegarServicio
    {
        public string ValidarNavegacion(string token, string role, IConfiguration config, char AdminView, string View);
    }
}
