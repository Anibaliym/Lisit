using App.Domain.Core.Domain;

namespace App.Domain.Entities
{
    public class Comuna : Entity, IAggregateRoot
    {
        public Comuna(Guid id, Guid idRegion, string nombre)
        {
            Id = id;
            IdRegion = idRegion;
            Nombre = nombre;
        }

        protected Comuna() { }

        //public Guid Id { get; set; }
        public Guid IdRegion { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
