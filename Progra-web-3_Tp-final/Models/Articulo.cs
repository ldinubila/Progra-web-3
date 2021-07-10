using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Progra_web_3_Tp_final.Models
{
    public partial class Articulo
    {
        public Articulo()
        {
            PedidoArticulos = new HashSet<PedidoArticulo>();
        }

        
        public int IdArticulo { get; set; }
        [Required(ErrorMessage ="Por favor ingrese un código")]
        [StringLength(50)]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Por favor ingrese una descripción")]
        [StringLength(300)]
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBorrado { get; set; }
        public int? CreadoPor { get; set; }
        public int? ModificadoPor { get; set; }
        public int? BorradoPor { get; set; }

        public virtual Usuario BorradoPorNavigation { get; set; }
        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual ICollection<PedidoArticulo> PedidoArticulos { get; set; }
    }
}
