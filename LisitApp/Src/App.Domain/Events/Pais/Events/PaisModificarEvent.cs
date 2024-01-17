using App.Domain.Core.Messaging;

namespace App.Domain.Events.Pais.Events
{
    public class PaisModificarEvent : Event
    {
        public PaisModificarEvent(Guid id, string nombre)
        {
            Id = id;
            Nombre = nombre;

            AggregateId = id;
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
