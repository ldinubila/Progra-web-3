using System.ComponentModel.DataAnnotations;

namespace Progra_web_3_Tp_final.ViewModels
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "El email es requerido.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
    }
}
