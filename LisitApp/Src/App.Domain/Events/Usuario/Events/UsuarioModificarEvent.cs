using App.Domain.Core.Messaging;

namespace App.Domain.Events.Usuario.Events
{
    public class UsuarioModificarEvent : Event
    {
        public UsuarioModificarEvent(Guid id, string rut, string nombre, string apellidoPaterno, string contrasena, string rol)
        {
            Id = id;

            Rut = rut; 
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            Contrasena = contrasena;
            Rol = rol;

            AggregateId = id;
        }

        public Guid Id { get; set; }
        public string Rut { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }
}
