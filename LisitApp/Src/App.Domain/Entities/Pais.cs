using App.Domain.Core.Domain;

namespace App.Domain.Entities
{
    public class Pais : Entity, IAggregateRoot
    {
        public Pais(Guid id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        protected Pais() { }

        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}

