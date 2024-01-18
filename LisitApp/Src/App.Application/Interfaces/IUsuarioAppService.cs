using App.Application.EventSourcedNormalizers;
using App.Application.ViewModels.Usuario;
using App.Domain.Core.Messaging;

namespace App.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        Task<UsuarioViewModel> BuscaPorId(Guid id);
        Task<UsuarioViewModel> BuscaPorRut(string rut);

        Task<CommandResponse> Crear(UsuarioCrearViewModel modelo);
        Task<CommandResponse> Modificar(UsuarioModificarViewModel modelo);
        Task<CommandResponse> Eliminar(Guid id);

        Task<IList<UsuarioHistoryData>> GetAllHistory(Guid id);
    }
}
