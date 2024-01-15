using App.Domain.Events.Usuario.Events;
using MediatR;

namespace App.Domain.Events.Usuario.Handlers
{
    public partial class UsuarioEliminarEventHandler : INotificationHandler<UsuarioEliminarEvent>
    {
        public Task Handle(UsuarioEliminarEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
