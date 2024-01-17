using App.Domain.Core.Messaging;
using App.Domain.Interfaces;

namespace App.Domain.Commands.Pais.Handlers
{
    public partial class PaisCommandHandler : CommandHandler
    {
        private readonly IPaisRepository _paisRepository;

        public PaisCommandHandler(IPaisRepository accionRepository)
        {
            _paisRepository = accionRepository ?? throw new ArgumentNullException(nameof(accionRepository));
        }
    }
}

