using App.Domain.Core.Data;
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repository
{
    public class AyudasSocialesRepository : IAyudasSocialesRepository
    {
        protected readonly LisitContext Db;
        protected readonly DbSet<AyudasSociales> DbSet;

        public IUnitOfWork UnitOfWork => Db;

        public AyudasSocialesRepository(LisitContext context)
        {
            Db = context;
            DbSet = Db.Set<AyudasSociales>();
        }

        public void Crear(AyudasSociales modelo)
        {
            DbSet.Add(modelo);
        }

        public async Task<AyudasSociales> BuscaPorId(Guid id)
        {
            return await DbSet.AsNoTracking().Where(ayudaSocial => ayudaSocial.Id == id).FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}