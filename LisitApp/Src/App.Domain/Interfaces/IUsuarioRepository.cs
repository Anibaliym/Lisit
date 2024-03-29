﻿using App.Domain.Core.Data;
using App.Domain.Entities;

namespace App.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        void Crear(Usuario modelo);
        void Modificar(Usuario modelo);
        void Eliminar(Usuario modelo);

        Task<Usuario> BuscaPor_Rut_Contrasena(string rut, string contrasena);
        Task<Usuario> BuscaPorId(Guid id);
        Task<Usuario> BuscaPorRut(string rut);

        Task<bool> EsUsuarioAdministrador(Guid id);
    }
}
