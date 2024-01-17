using App.Domain.Core.Messaging;

namespace App.Domain.Events.Comuna.Events
{
    public class ComunaCrearEvent : Event
    {
        public ComunaCrearEvent(Guid id, Guid idRegion, string nombre)
        {
            Id = id;
            IdRegion = idRegion;
            Nombre = nombre;

            AggregateId = id;
        }

        public Guid Id { get; set; }
        public Guid IdRegion { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
