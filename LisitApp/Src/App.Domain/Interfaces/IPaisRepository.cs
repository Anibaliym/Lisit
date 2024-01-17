using App.Domain.Core.Data;
using App.Domain.Entities;

namespace App.Domain.Interfaces
{
    public interface IPaisRepository : IRepository<Pais>
    {
        void Crear(Pais modelo);
        void Modificar(Pais modelo);
        void Eliminar(Pais modelo);

        Task<Pais> BuscaPorId(Guid id);
        Task<Pais> BuscaPorNombrePais(string nombre);
   }
}
