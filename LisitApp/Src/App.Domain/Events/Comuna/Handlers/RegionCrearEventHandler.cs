using App.Domain.Events.Comuna.Events;
using MediatR;

namespace App.Domain.Events.Comuna.Handlers
{
    public partial class ComunaCrearEventHandler : INotificationHandler<ComunaCrearEvent>
    {
        public Task Handle(ComunaCrearEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
