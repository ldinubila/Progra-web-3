using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios
{
    public class NavegarServicio : INavegarServicio
    {
        private TokenServicio _tokenServicio;
        private IConfiguration _configuration;

        public string ValidarNavegacion(string token, string role, IConfiguration config, char AdminView, string View)
        {
            _configuration = config;
            _tokenServicio = new TokenServicio();

            var secretKey = _configuration.GetValue<string>("SecretKey");

            if (!_tokenServicio.ValidarTokenId(secretKey, token))
            {
                return "Home";
            }

            if (AdminView == 'N')
            {
                return "OK";
            }
            else
            {
                if (role == "Admin")
                {
                    return "OK";
                }

                return "Home";
            }

        }
    }
}
