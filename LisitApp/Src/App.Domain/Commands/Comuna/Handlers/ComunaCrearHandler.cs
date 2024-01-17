using App.Domain.Commands.Comuna.Commands;
using App.Domain.Core.Messaging;
using App.Domain.Events.Comuna.Events;
using MediatR;

namespace App.Domain.Commands.Comuna.Handlers
{
    public partial class ComunaCommandHandler : IRequestHandler<ComunaCrearCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(ComunaCrearCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var comuna = new Entities.Comuna(Guid.NewGuid(), message.IdRegion, message.Nombre);

            var existeComuna = await _comunaRepository.BuscaPorNombreComuna(message.Nombre);

            if (existeComuna != null)
            {
                AddError($"Ya existe una comuna con el nombre '{message.Nombre}'. Operación Cancelada");
                return CommandResponse;
            }

            comuna.AddDomainEvent(new ComunaCrearEvent(
                comuna.Id,
                comuna.IdRegion,
                comuna.Nombre
            ));

            _comunaRepository.Crear(comuna);

            CommandResponse.Data = comuna;
            CommandResponse.Result = true;

            return await Commit(_comunaRepository.UnitOfWork);
        }
    }
}
