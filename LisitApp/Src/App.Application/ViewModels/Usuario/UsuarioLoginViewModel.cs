using System.ComponentModel;

namespace App.Application.ViewModels.Usuario
{
    public class UsuarioLoginViewModel
    {
        [DisplayName("Acceso")]
        public bool Acceso { get; set; } = false;

        [DisplayName("Información Usuario")]
        public UsuarioInformacionUsuarioConectadoViewModel DatosUsuario { get; set; }

        [DisplayName("Informacion")]
        public string Info { get; set; } = "NO AUTORIZADO";
    }
}
