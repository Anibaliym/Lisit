using App.Domain.Core.Data;
using App.Domain.Entities;

namespace App.Domain.Interfaces
{
    public interface IComunaRepository : IRepository<Comuna>
    {
        void Crear(Comuna modelo);
        //void Modificar(Comuna modelo);
        //void Eliminar(Comuna modelo);

        Task<Comuna> BuscaPorId(Guid id);
        Task<Comuna> BuscaPorNombreComuna(string nombre);
    }
}
