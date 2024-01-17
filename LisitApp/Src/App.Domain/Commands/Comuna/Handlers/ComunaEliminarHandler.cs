using App.Domain.Commands.Comuna.Commands;
using App.Domain.Core.Messaging;
using MediatR;

namespace App.Domain.Commands.Comuna.Handlers
{
    public partial class ComunaCommandHandler : IRequestHandler<ComunaEliminarCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(ComunaEliminarCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var existeComuna = await _comunaRepository.BuscaPorId(message.Id);

            if (existeComuna == null)
            {
                AddError($"No existe la comuna con el id '{message.Id}'. Operación cancelada.");
                return CommandResponse;
            }

            //Pendiente
            //existeComuna.AddDomainEvent(new ComunaEliminarEvent(existeComuna.Id));

            //_comunaRepository.Eliminar(existeComuna);

            CommandResponse.Data = null;
            CommandResponse.Result = true;

            return await Commit(_comunaRepository.UnitOfWork);
        }
    }
}
