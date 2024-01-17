using App.Domain.Events.Region.Events;
using MediatR;

namespace App.Domain.Events.Region.Handlers
{
    public partial class RegionCrearEventHandler : INotificationHandler<RegionCrearEvent>
    {
        public Task Handle(RegionCrearEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}