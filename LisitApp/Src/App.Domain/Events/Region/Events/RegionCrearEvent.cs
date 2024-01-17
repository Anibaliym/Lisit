using App.Domain.Core.Messaging;

namespace App.Domain.Events.Region.Events
{
    public class RegionCrearEvent : Event
    {
        public RegionCrearEvent(Guid id, Guid idPais, string nombre)
        {
            Id = id;
            IdPais = idPais;
            Nombre = nombre;

            AggregateId = id;
        }

        public Guid Id { get; set; }
        public Guid IdPais { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}