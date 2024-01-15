using App.Domain.Core.Data;
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        protected readonly LisitContext Db;
        protected readonly DbSet<Usuario> DbSet;
        
        
        public IUnitOfWork UnitOfWork => Db;

        public UsuarioRepository(LisitContext context)
        {
            Db = context;
            DbSet = Db.Set<Usuario>();
        }

        public void Crear(Usuario modelo)
        {
            DbSet.Add(modelo);
        }

        public void Modificar(Usuario modelo)
        {
            DbSet.Update(modelo);
        }

        public void Eliminar(Usuario modelo)
        {
            DbSet.Remove(modelo);
        }

        public async Task<Usuario> BuscaPorId(Guid id)
        {
            return await DbSet.AsNoTracking().Where(usuario => usuario.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Usuario> BuscaPorRut(string rut)
        {
            return await DbSet.AsNoTracking().Where(usuario => usuario.Rut == rut).FirstOrDefaultAsync();
        }
        public async Task<Usuario> LoginUsuario(string rut, string contrasena)
        {
            return await DbSet.AsNoTracking().Where(usuario => usuario.Rut == rut & usuario.Contrasena == contrasena).FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
