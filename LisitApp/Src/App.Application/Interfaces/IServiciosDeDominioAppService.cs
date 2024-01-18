using App.Application.ViewModels.ServiciosDeDominio;
using App.Application.ViewModels.Usuario;
using App.Domain.Core.Messaging;
using App.Domain.Entities;

namespace App.Application.Interfaces
{
    public interface IServiciosDeDominioAppService : IDisposable
    {
        Task<CommandResponse> LoginUsuario(string rut, string contrasena);
        Task<CommandResponse> RegistrarUsuario(UsuarioCrearViewModel modelo);
        Task<CommandResponse> CrearAyudaSocialAdministrador(CrearAyudasSocialViewModel modelo);
        Task<CommandResponse> RegistrarAsignacion(RegistrarAsignacionViewModel modelo);
        Task<CommandResponse> VerAyudasSocialesUsuarioAdmin(Guid idUsuarioGestionador, Guid idUsuarioAConsultar);
        Task<CommandResponse> VerAyudasSocialesVigentePorAnio(Guid idUsuario);
    }
}
