using App.Domain.Core.Domain;

namespace App.Domain.Entities
{
    public class Region : Entity, IAggregateRoot
    {
        public Region(Guid id, Guid idPais, string nombre)
        {
            Id = id;
            IdPais = idPais;
            Nombre = nombre;
        }

        protected Region() { }

        public Guid Id { get; set; }
        public Guid IdPais { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}

