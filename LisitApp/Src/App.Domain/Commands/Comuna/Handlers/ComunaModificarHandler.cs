using App.Domain.Commands.Comuna.Commands;
using App.Domain.Core.Messaging;
using MediatR;

namespace App.Domain.Commands.Comuna.Handlers
{
    public partial class ComunaCommandHandler : IRequestHandler<ComunaModificarCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(ComunaModificarCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var comuna = new Entities.Comuna(message.Id, message.IdRegion, message.Nombre);

            var existeComuna = await _comunaRepository.BuscaPorId(message.Id);

            if (existeComuna == null)
            {
                AddError($"No existe la comuna con el id '{message.Id}'.");
                return CommandResponse;
            }

            //ayanez - pendiente
            //comuna.AddDomainEvent(new ComunaModificarEvent(
            //    comuna.Id,
            //    comuna.IdRegion, 
            //    comuna.Nombre
            //));

            //_comunaRepository.Modificar(comuna);

            CommandResponse.Data = comuna;
            CommandResponse.Result = true;

            return await Commit(_comunaRepository.UnitOfWork);
        }
    }
}
