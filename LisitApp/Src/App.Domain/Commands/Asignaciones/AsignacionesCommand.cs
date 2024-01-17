using App.Domain.Core.Messaging;

namespace App.Domain.Commands.Asignaciones
{
    public abstract class AsignacionesCommand : Command
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdAyudaSocial { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
}
