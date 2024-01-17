using App.Domain.Commands.Asignaciones.Commands;
using App.Domain.Core.Messaging;
using App.Domain.Events.Asignaciones.Events;
using MediatR;

namespace App.Domain.Commands.Asignaciones.Handlers
{
    public partial class AsignacionesCommandHandler : IRequestHandler<AsignacionesCrearCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(AsignacionesCrearCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var asinaciones = new Entities.Asignaciones(Guid.NewGuid(), message.IdUsuario, message.IdAyudaSocial, message.FechaAsignacion);

            var existeAsignacion = await _asignacionesRepository.BuscaPorId(message.Id);

            if (existeAsignacion != null)
            {
                AddError($"Ya existe una asignación con el id '{existeAsignacion.Id}'. Operación Cancelada");
                return CommandResponse;
            }

            asinaciones.AddDomainEvent(new AsignacionesCrearEvent(asinaciones.Id, asinaciones.IdUsuario, asinaciones.IdAyudaSocial, asinaciones.FechaAsignacion));

            _asignacionesRepository.Crear(asinaciones);

            CommandResponse.Data = asinaciones;
            CommandResponse.Result = true;

            return await Commit(_asignacionesRepository.UnitOfWork);
        }
    }
}
