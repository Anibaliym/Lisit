using App.Domain.Core.Messaging;
using App.Domain.Interfaces;

namespace App.Domain.Commands.Comuna.Handlers
{
    public partial class ComunaCommandHandler : CommandHandler
    {
        private readonly IComunaRepository _comunaRepository;

        public ComunaCommandHandler(IComunaRepository accionRepository)
        {
            _comunaRepository = accionRepository ?? throw new ArgumentNullException(nameof(accionRepository));
        }
    }
}
