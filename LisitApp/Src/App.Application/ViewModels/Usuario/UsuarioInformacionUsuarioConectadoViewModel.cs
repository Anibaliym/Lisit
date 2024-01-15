using System.ComponentModel;

namespace App.Application.ViewModels.Usuario
{
    public class UsuarioInformacionUsuarioConectadoViewModel
    {
        [DisplayName("Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [DisplayName("ApellidoPaterno")]
        public string ApellidoPaterno { get; set; } = string.Empty;

        [DisplayName("Rol Usuario")]
        public string Rol { get; set; } = string.Empty;
    }
}
