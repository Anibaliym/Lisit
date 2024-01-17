using App.Domain.Core.Domain;

namespace App.Domain.Entities
{
    public class AyudasSociales : Entity, IAggregateRoot
    {
        public AyudasSociales(Guid id, Guid idComuna, string descripcion, int anio)
        {
            Id = id;
            IdComuna = idComuna;
            Descripcion = descripcion;
            Anio = anio;
        }

        protected AyudasSociales() { }

        public Guid IdComuna { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int Anio { get; set; }
    }
}
