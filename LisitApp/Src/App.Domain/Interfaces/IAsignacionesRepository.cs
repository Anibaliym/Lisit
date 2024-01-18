using App.Domain.Core.Data;
using App.Domain.Entities;

namespace App.Domain.Interfaces
{
    public interface IAsignacionesRepository : IRepository<Asignaciones>
    {
        void Crear(Asignaciones modelo);
        Task<Asignaciones> BuscaPorId(Guid id);
        Task<Asignaciones> Busca_AyudaSocialUsuario(Guid idAyudaSocial, Guid idUsuario);
        Task<IList<Asignaciones>> BuscaPorIdUsuario(Guid idUsuario);
    }
}
