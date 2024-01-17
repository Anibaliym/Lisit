using App.Domain.Core.Data;
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repository
{
    public class RegionRepository : IRegionRepository
    {
        protected readonly LisitContext Db;
        protected readonly DbSet<Region> DbSet;

        public IUnitOfWork UnitOfWork => Db;

        public RegionRepository(LisitContext context)
        {
            Db = context;
            DbSet = Db.Set<Region>();
        }

        public async Task<Region> BuscaPorId(Guid id)
        {
            return await DbSet.AsNoTracking().Where(pais => pais.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Region> BuscaPorNombreRegion(string nombre)
        {
            return await DbSet.AsNoTracking().Where(pais => pais.Nombre == nombre).FirstOrDefaultAsync();
        }

        public void Crear(Region modelo)
        {
            DbSet.Add(modelo);
        }

        public void Eliminar(Region modelo)
        {
            DbSet.Remove(modelo);
        }

        public void Modificar(Region modelo)
        {
            DbSet.Update(modelo);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
