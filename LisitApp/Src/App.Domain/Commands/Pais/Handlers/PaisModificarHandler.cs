using App.Domain.Commands.Pais.Commands;
using App.Domain.Core.Messaging;
using App.Domain.Events.Pais.Events;
using MediatR;

namespace App.Domain.Commands.Pais.Handlers
{
    public partial class PaisCommandHandler : IRequestHandler<PaisModificarCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(PaisModificarCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var pais = new Entities.Pais(message.Id, message.Nombre);

            var existePais = await _paisRepository.BuscaPorId(message.Id);

            if (existePais == null)
            {
                AddError($"No existe el Pais con el id '{message.Id}'.");
                return CommandResponse;
            }

            pais.AddDomainEvent(new PaisModificarEvent(pais.Id, pais.Nombre));

            _paisRepository.Modificar(pais);

            CommandResponse.Data = pais;
            CommandResponse.Result = true;

            return await Commit(_paisRepository.UnitOfWork);
        }
    }
}
