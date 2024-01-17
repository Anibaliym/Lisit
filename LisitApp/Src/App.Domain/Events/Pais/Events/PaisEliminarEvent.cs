using App.Domain.Core.Messaging;

namespace App.Domain.Events.Pais.Events
{
    public class PaisEliminarEvent : Event
    {
        public PaisEliminarEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }

        public Guid Id { get; set; }
    }

}
