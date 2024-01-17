using App.Application.ViewModels.Asignaciones;
using App.Domain.Core.Messaging;

namespace App.Application.Interfaces
{
    public interface IAsignacionesAppService : IDisposable
    {
        Task<CommandResponse> Crear(AsignacionesCrearViewModel modelo);
        Task<AsignacionesViewModel> BuscaPorId(Guid id);
    }
}
