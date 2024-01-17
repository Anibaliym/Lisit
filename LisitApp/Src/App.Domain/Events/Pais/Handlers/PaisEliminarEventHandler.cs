using App.Domain.Events.Pais.Events;
using MediatR;

namespace App.Domain.Events.Pais.Handlers
{
    public partial class PaisEliminarEventHandler : INotificationHandler<PaisEliminarEvent>
    {
        public Task Handle(PaisEliminarEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
