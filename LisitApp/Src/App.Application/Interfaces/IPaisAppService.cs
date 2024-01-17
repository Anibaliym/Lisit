using App.Application.ViewModels.Pais;
using App.Domain.Core.Messaging;

namespace App.Application.Interfaces
{
    public interface IPaisAppService : IDisposable
    {
        Task<CommandResponse> Crear(PaisCrearViewModel modelo);
        //Task<CommandResponse> Modificar(PaisViewModel modelo);
        //Task<CommandResponse> Eliminar(Guid id);

        Task<PaisViewModel> BuscaPorId(Guid id);
        Task<PaisViewModel> BuscaPorNombrePais(string nombre);
    }
}
