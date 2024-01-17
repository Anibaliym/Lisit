using App.Domain.Events.Pais.Events;
using MediatR;

namespace App.Domain.Events.Pais.Handlers
{
    public partial class PaisCrearEventHandler : INotificationHandler<PaisCrearEvent>
    {
        public Task Handle(PaisCrearEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
