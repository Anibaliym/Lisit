using App.Application.ViewModels.AyudasSociales;
using App.Domain.Core.Messaging;

namespace App.Application.Interfaces
{
    public interface IAyudasSocialesAppService : IDisposable
    {
        Task<CommandResponse> Crear(AyudasSocialesCrearViewModel modelo);
        Task<AyudasSocialesViewModel> BuscaPorId(Guid id);
    }
}
