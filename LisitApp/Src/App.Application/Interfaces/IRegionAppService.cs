using App.Application.EventSourcedNormalizers;
using App.Application.ViewModels.Region;
using App.Domain.Core.Messaging;

namespace App.Application.Interfaces
{
    public interface IRegionAppService : IDisposable
    {
        Task<CommandResponse> Crear(RegionCrearViewModel modelo);
        //Task<CommandResponse> Modificar(RegionViewModel modelo);
        //Task<CommandResponse> Eliminar(Guid id);

        Task<RegionViewModel> BuscaPorId(Guid id);
        Task<RegionViewModel> BuscaPorNombreRegion(string nombre);

        Task<IList<RegionHistoryData>> GetAllHistory(Guid id);
    }
}
