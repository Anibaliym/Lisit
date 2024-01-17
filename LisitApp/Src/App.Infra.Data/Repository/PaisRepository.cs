using App.Domain.Core.Data;
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repository
{
    public class PaisRepository : IPaisRepository
    {
        protected readonly LisitContext Db;
        protected readonly DbSet<Pais> DbSet;

        public IUnitOfWork UnitOfWork => Db;

        public PaisRepository(LisitContext context)
        {
            Db = context;
            DbSet = Db.Set<Pais>();
        }

        public async Task<Pais> BuscaPorId(Guid id)
        {
            return await DbSet.AsNoTracking().Where(pais => pais.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Pais> BuscaPorNombrePais(string nombre)
        {
            return await DbSet.AsNoTracking().Where(pais => pais.Nombre == nombre).FirstOrDefaultAsync();
        }

        public void Crear(Pais modelo)
        {
            DbSet.Add(modelo);
        }

        public void Eliminar(Pais modelo)
        {
            DbSet.Remove(modelo);
        }

        public void Modificar(Pais modelo)
        {
            DbSet.Update(modelo);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
