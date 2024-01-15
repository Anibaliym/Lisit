using App.Domain.Events.Usuario.Events;
using MediatR;

namespace App.Domain.Events.Usuario.Handlers
{
    public partial class UsuarioModificarEventHandler : INotificationHandler<UsuarioModificarEvent>
    {
        public Task Handle(UsuarioModificarEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
