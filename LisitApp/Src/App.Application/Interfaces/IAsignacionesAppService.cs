using App.Application.EventSourcedNormalizers;
using App.Application.ViewModels.Asignaciones;
using App.Application.ViewModels.AyudasSociales;
using App.Domain.Core.Messaging;

namespace App.Application.Interfaces
{
    public interface IAsignacionesAppService : IDisposable
    {
        Task<CommandResponse> Crear(AsignacionesCrearViewModel modelo);
        Task<AsignacionesViewModel> BuscaPorId(Guid id);
        Task<AyudasSocialesViewModel> Busca_AyudaSocialUsuario(Guid idAyudaSocial, Guid idUsuario);
        Task<IList<AsignacionesViewModel>> BuscaPorIdUsuario(Guid idUsuario);

        Task<IList<AsignacionesHistoryData>> GetAllHistory(Guid id);
    }
}
