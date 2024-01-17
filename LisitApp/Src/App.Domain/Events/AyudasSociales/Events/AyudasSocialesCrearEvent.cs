using App.Domain.Core.Messaging;

namespace App.Domain.Events.AyudasSociales.Events
{
    public class AyudasSocialesCrearEvent : Event
    {
        public AyudasSocialesCrearEvent(Guid id, Guid idComuna, string descripcion, int anio)
        {
            Id = id;
            IdComuna = idComuna;
            Descripcion = descripcion;
            Anio = anio;

            AggregateId = id;
        }

        public Guid Id { get; set; }
        public Guid IdComuna { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int Anio { get; set; }
    }
}
