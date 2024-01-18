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

        public async Task<int> Busca_AnioAyudaSocial(Guid id)
        {
            int anio = 0; 

            var ayudaSocial = await DbSet.AsNoTracking().Where(usuario => usuario.Id == id).FirstOrDefaultAsync();
            
            if (ayudaSocial != null) {
                anio = ayudaSocial.Anio; 
            }

            return anio;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<object> Busca_AnioAyudayAsignacionesUsuario(Guid idUsuario)
        {
            var consulta = from ayuda in Db.AyudasSociales
                           join asig in Db.Asignaciones on ayuda.Id equals asig.IdAyudaSocial
                           where asig.IdUsuario == idUsuario
                           orderby ayuda.Anio
                           select new
                           {
                               ayuda.Descripcion,
                               ayuda.Anio,
                               asig.FechaAsignacion,
                               asig.IdUsuario
                           };

            return consulta.ToList(); 
        }
    }
}