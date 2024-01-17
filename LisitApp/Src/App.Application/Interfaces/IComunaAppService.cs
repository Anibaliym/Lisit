using App.Application.ViewModels.Comuna;
using App.Domain.Core.Messaging;

namespace App.Application.Interfaces
{
    public interface IComunaAppService : IDisposable
    {
        Task<CommandResponse> Crear(ComunaCrearViewModel modelo);
        //Task<CommandResponse> Modificar(ComunaViewModel modelo);
        //Task<CommandResponse> Eliminar(Guid id);

        Task<ComunaViewModel> BuscaPorId(Guid id);
        Task<ComunaViewModel> BuscaPorNombreComuna(string nombre);
    }
}
