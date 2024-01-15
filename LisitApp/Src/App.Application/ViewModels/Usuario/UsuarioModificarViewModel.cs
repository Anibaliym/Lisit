using System.ComponentModel;

namespace App.Application.ViewModels.Usuario
{
    public class UsuarioModificarViewModel
    {
        [DisplayName("Identificador")]
        public Guid Id { get; set; }

        [DisplayName("Rut")]
        public string Rut { get; set; } = string.Empty;

        [DisplayName("Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [DisplayName("Apellido Paterno")]
        public string ApellidoPaterno { get; set; } = string.Empty;

        [DisplayName("Contraseña")]
        public string Contrasena { get; set; } = string.Empty;

        [DisplayName("Rol")]
        public string Rol { get; set; } = string.Empty;
    }
}
