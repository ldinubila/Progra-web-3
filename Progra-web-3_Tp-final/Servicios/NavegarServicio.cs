using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra_web_3_Tp_final.Servicios
{
    public class NavegarServicio : INavegarServicio
    {
        private TokenServicio _tokenServicio;
        private IConfiguration _configuration;

        public string ValidarNavegacion(string token, string role, IConfiguration config, char AdminView, String View)
        {
            _configuration = config;
            _tokenServicio = new TokenServicio();

            var secretKey = _configuration.GetValue<string>("SecretKey");

            if (!_tokenServicio.ValidarTokenId(secretKey, token))
            {
                return "Home";
            }


            if (AdminView == 'Y' && role == "Admin")
            {
                return View;
            }
            else if (AdminView == 'Y' && role != "Admin")
            {
                return "Error";
            }
            else
            {
                return View;
            }

        }
    }
}
