using App.Domain.Events.Pais.Events;
using MediatR;

namespace App.Domain.Events.Pais.Handlers
{
    public partial class PaisModificarEventHandler : INotificationHandler<PaisModificarEvent>
    {
        public Task Handle(PaisModificarEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
