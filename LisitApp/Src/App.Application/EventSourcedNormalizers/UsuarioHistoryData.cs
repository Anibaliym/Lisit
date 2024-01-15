using App.Domain.Core.Models;

namespace App.Application.EventSourcedNormalizers
{
    public class UsuarioHistoryData : HistoryData
    {
        public string Id { get; set; }
        public string Rut { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }
}
