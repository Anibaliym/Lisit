using App.Domain.Core.Messaging;
using App.Domain.Interfaces;

namespace App.Domain.Commands.Asignaciones.Handlers
{
    public partial class AsignacionesCommandHandler : CommandHandler
    {
        private readonly IAsignacionesRepository _asignacionesRepository;

        public AsignacionesCommandHandler(IAsignacionesRepository accionRepository)
        {
            _asignacionesRepository = accionRepository ?? throw new ArgumentNullException(nameof(accionRepository));
        }
    }

}
