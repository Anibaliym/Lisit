using App.Application.EventSourcedNormalizers;
using App.Application.ViewModels.Usuario;
using App.Domain.Core.Messaging;

namespace App.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        Task<CommandResponse> Crear(UsuarioCrearViewModel modelo);
        Task<CommandResponse> Modificar(UsuarioModificarViewModel modelo);
        Task<CommandResponse> Eliminar(Guid id);
        Task<UsuarioViewModel> BuscaPorId(Guid id);
        Task<CommandResponse> LoginUsuario(string rut, string contrasena);
        Task<UsuarioViewModel> BuscaPorRut(string rut);

        Task<IList<UsuarioHistoryData>> GetAllHistory(Guid id);
    }
}
