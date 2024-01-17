using App.Domain.Core.Data;
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repository
{
    public class AsignacionesRepository : IAsignacionesRepository
    {
        protected readonly LisitContext Db;
        protected readonly DbSet<Asignaciones> DbSet;
        public IUnitOfWork UnitOfWork => Db;

        public AsignacionesRepository(LisitContext context)
        {
            Db = context;
            DbSet = Db.Set<Asignaciones>();
        }

        public void Crear(Asignaciones modelo)
        {
            DbSet.Add(modelo);
        }

        public async Task<Asignaciones> BuscaPorId(Guid id)
        {
            var x = await DbSet.AsNoTracking().Where(asignaciones => asignaciones.Id == id).FirstOrDefaultAsync();


            return await DbSet.AsNoTracking().Where(asignaciones => asignaciones.Id == id).FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
