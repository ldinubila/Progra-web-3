using System;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios
{
    public interface INavegarServicio
    {
        public string ValidarNavegacion(string token, string role, IConfiguration config, char AdminView, string View);
    }
}
