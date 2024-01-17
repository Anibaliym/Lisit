using App.Domain.Core.Messaging;

namespace App.Domain.Events.Asignaciones.Events
{
    public class AsignacionesCrearEvent : Event
    {
        public AsignacionesCrearEvent(Guid id, Guid idUsuario, Guid idAyudaSocial, DateTime fechaAsignacion)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdAyudaSocial = idAyudaSocial;
            FechaAsignacion = fechaAsignacion;

            AggregateId = id;
        }

        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdAyudaSocial { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
}
