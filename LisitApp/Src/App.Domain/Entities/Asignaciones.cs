using App.Domain.Core.Domain;

namespace App.Domain.Entities
{
    public class Asignaciones : Entity, IAggregateRoot
    {
        public Asignaciones(Guid id, Guid idUsuario, Guid idAyudaSocial, DateTime fechaAsignacion)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdAyudaSocial = idAyudaSocial;
            FechaAsignacion = fechaAsignacion;
        }

        protected Asignaciones() { }

        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdAyudaSocial { get; set; }
        public DateTime FechaAsignacion { get; set; }

    }
}
