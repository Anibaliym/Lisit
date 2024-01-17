using App.Domain.Core.Messaging;
using App.Domain.Interfaces;

namespace App.Domain.Commands.AyudasSociales.Handlers
{
    public partial class AyudasSocialesCommandHandler : CommandHandler
    {
        private readonly IAyudasSocialesRepository _ayudasSocialesRepository;

        public AyudasSocialesCommandHandler(IAyudasSocialesRepository accionRepository)
        {
            _ayudasSocialesRepository = accionRepository ?? throw new ArgumentNullException(nameof(accionRepository));
        }
    }

}
