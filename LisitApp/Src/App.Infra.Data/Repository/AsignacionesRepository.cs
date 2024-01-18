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
            return await DbSet.AsNoTracking().Where(asignaciones => asignaciones.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Asignaciones> Busca_AyudaSocialUsuario(Guid idAyudaSocial, Guid idUsuario)
        {
            return await DbSet.AsNoTracking().Where(asignaciones => asignaciones.IdAyudaSocial == idAyudaSocial & asignaciones.IdUsuario == idUsuario).FirstOrDefaultAsync();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IList<Asignaciones>> BuscaPorIdUsuario(Guid idUsuario)
        {
            return await DbSet.AsNoTracking().Where(item => item.IdUsuario == idUsuario).ToListAsync();
        }
    }
}
