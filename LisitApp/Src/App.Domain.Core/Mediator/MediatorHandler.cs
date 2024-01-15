using App.Domain.Core.Messaging;

namespace App.Domain.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task<CommandResponse> SendCommand<T>(T command) where T : Command;
    }
}
