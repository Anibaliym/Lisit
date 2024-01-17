using App.Domain.Core.Data;
using App.Domain.Entities;

namespace App.Domain.Interfaces
{
    public interface IRegionRepository : IRepository<Region>
    {
        void Crear(Region modelo);
        //void Modificar(Region modelo);
        //void Eliminar(Region modelo);

        Task<Region> BuscaPorId(Guid id);
        Task<Region> BuscaPorNombreRegion(string nombre);
    }
}
