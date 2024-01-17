using App.Domain.Commands.Region.Commands;
using App.Domain.Core.Messaging;
using App.Domain.Events.Comuna.Events;
using MediatR;

namespace App.Domain.Commands.Region.Handlers
{
    public partial class RegionCommandHandler : IRequestHandler<RegionCrearCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(RegionCrearCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var region = new Entities.Region(Guid.NewGuid(), message.IdPais, message.Nombre);

            var existeRegion = await _regionRepository.BuscaPorNombreRegion(message.Nombre);

            if (existeRegion != null)
            {
                AddError($"Ya existe una Region con el nombre '{message.Nombre}'. Operación Cancelada");
                return CommandResponse;
            }

            region.AddDomainEvent(new ComunaCrearEvent(
                region.Id,
                region.IdPais,
                region.Nombre
            ));

            _regionRepository.Crear(region);

            CommandResponse.Data = region;
            CommandResponse.Result = true;

            return await Commit(_regionRepository.UnitOfWork);
        }
    }
}
