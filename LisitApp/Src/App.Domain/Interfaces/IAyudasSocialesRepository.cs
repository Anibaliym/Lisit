using App.Domain.Core.Data;
using App.Domain.Entities;

namespace App.Domain.Interfaces
{
    public interface IAyudasSocialesRepository : IRepository<AyudasSociales>
    {
        void Crear(AyudasSociales modelo);
        Task<AyudasSociales> BuscaPorId(Guid id);
    }
}
