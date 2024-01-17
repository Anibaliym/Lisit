using App.Domain.Core.Data;
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repository
{
    public class ComunaRepository : IComunaRepository
    {
        protected readonly LisitContext Db;
        protected readonly DbSet<Comuna> DbSet;

        public IUnitOfWork UnitOfWork => Db;

        public ComunaRepository(LisitContext context)
        {
            Db = context;
            DbSet = Db.Set<Comuna>();
        }

        public async Task<Comuna> BuscaPorId(Guid id)
        {
            return await DbSet.AsNoTracking().Where(pais => pais.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Comuna> BuscaPorNombreComuna(string nombre)
        {
            return await DbSet.AsNoTracking().Where(comuna => comuna.Nombre == nombre).FirstOrDefaultAsync();
        }

        public void Crear(Comuna modelo)
        {
            DbSet.Add(modelo);
        }

        public void Eliminar(Comuna modelo)
        {
            DbSet.Remove(modelo);
        }

        public void Modificar(Comuna modelo)
        {
            DbSet.Update(modelo);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
