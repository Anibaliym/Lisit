using App.Domain.Events.AyudasSociales.Events;
using MediatR;

namespace App.Domain.Events.AyudasSociales.Handlers
{
    public partial class AyudasSocialesCrearEventHandler : INotificationHandler<AyudasSocialesCrearEvent>
    {
        public Task Handle(AyudasSocialesCrearEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
