using App.Domain.Events.Asignaciones.Events;
using MediatR;

namespace App.Domain.Events.Asignaciones.Handlers
{
    public partial class AsignacionesCrearEventHandler : INotificationHandler<AsignacionesCrearEvent>
    {
        public Task Handle(AsignacionesCrearEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }

}
