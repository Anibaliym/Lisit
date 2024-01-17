using App.Domain.Commands.Pais.Commands;
using App.Domain.Core.Messaging;
using App.Domain.Events.Pais.Events;
using MediatR;

namespace App.Domain.Commands.Pais.Handlers
{
    public partial class PaisCommandHandler : IRequestHandler<PaisEliminarCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(PaisEliminarCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var existePais = await _paisRepository.BuscaPorId(message.Id);

            if (existePais == null)
            {
                AddError($"No existe el Pais con el id '{message.Id}'. Operación cancelada.");
                return CommandResponse;
            }

            existePais.AddDomainEvent(new PaisEliminarEvent(existePais.Id));

            _paisRepository.Eliminar(existePais);

            CommandResponse.Data = null;
            CommandResponse.Result = true;

            return await Commit(_paisRepository.UnitOfWork);
        }
    }
}
