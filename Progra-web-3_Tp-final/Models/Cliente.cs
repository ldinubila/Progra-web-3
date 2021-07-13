using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Progra_web_3_Tp_final.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdCliente { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El numero debe contener solo numeros")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Cuit { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBorrado { get; set; }
        public int? ModificadoPor { get; set; }
        public int? CreadoPor { get; set; }
        public int? BorradoPor { get; set; }

        public virtual Usuario BorradoPorNavigation { get; set; }
        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
