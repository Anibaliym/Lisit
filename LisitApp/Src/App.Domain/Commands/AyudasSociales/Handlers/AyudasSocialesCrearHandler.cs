using App.Domain.Commands.AyudasSociales.Commands;
using App.Domain.Core.Messaging;
using App.Domain.Events.AyudasSociales.Events;
using MediatR;

namespace App.Domain.Commands.AyudasSociales.Handlers
{
    public partial class AyudasSocialesCommandHandler : IRequestHandler<AyudasSocialesCrearCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(AyudasSocialesCrearCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var ayudasSociales = new Entities.AyudasSociales(Guid.NewGuid(), message.IdComuna, message.Descripcion, message.Anio);

            var existeAyudasSociales = await _ayudasSocialesRepository.BuscaPorId(message.Id);

            if (existeAyudasSociales != null)
            {
                AddError($"Ya existe una ayuda social con el campo 'ID' '{message.Id}'. Operación Cancelada");
                return CommandResponse;
            }

            ayudasSociales.AddDomainEvent(new AyudasSocialesCrearEvent(
                ayudasSociales.Id,
                ayudasSociales.IdComuna,
                ayudasSociales.Descripcion,
                ayudasSociales.Anio
            ));

            _ayudasSocialesRepository.Crear(ayudasSociales);

            CommandResponse.Data = ayudasSociales;
            CommandResponse.Result = true;

            return await Commit(_ayudasSocialesRepository.UnitOfWork);
        }
    }
}
