using App.Domain.Core.Data;
using App.Domain.Entities;
using App.Domain.Enumerations.Usuario;
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
        public async Task<Usuario> BuscaPor_Rut_Contrasena(string rut, string contrasena)
        {
            return await DbSet.AsNoTracking().Where(usuario => usuario.Rut == rut & usuario.Contrasena == contrasena).FirstOrDefaultAsync();
        }
        public async Task<bool> EsUsuarioAdministrador(Guid id)
        {
            var esAdmin = await DbSet.AsNoTracking().Where(usuario => usuario.Id == id & usuario.Rol == RolUsuarioEnum.ADMINISTRADOR.Name).FirstOrDefaultAsync();

            return (esAdmin == null) ? false : true;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
