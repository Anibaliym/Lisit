using App.Domain.Commands.Pais.Commands;
using App.Domain.Core.Messaging;
using App.Domain.Events.Pais.Events;
using MediatR;

namespace App.Domain.Commands.Pais.Handlers
{
    public partial class PaisCommandHandler : IRequestHandler<PaisCrearCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(PaisCrearCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var pais = new Entities.Pais(Guid.NewGuid(), message.Nombre.ToUpper());

            var existePais = await _paisRepository.BuscaPorNombrePais(message.Nombre);

            if (existePais != null)
            {
                AddError($"Ya existe el pais con el nombre '{existePais.Nombre}'. Operación Cancelada");
                return CommandResponse;
            }

            pais.AddDomainEvent(new PaisCrearEvent(pais.Id,pais.Nombre));

            _paisRepository.Crear(pais);

            CommandResponse.Data = pais;
            CommandResponse.Result = true;

            return await Commit(_paisRepository.UnitOfWork);
        }
    }
}
