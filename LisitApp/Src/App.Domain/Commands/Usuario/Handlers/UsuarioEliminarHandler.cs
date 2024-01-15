using MediatR;
using App.Domain.Commands.Usuario.Commands;
using App.Domain.Core.Messaging;
using App.Domain.Events.Usuario.Events;

namespace App.Domain.Commands.Usuario.Handlers
{
    public partial class UsuarioCommandHandler : IRequestHandler<UsuarioEliminarCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(UsuarioEliminarCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var existeUsuario = await _usuarioRepository.BuscaPorId(message.Id);

            if (existeUsuario == null)
            {
                AddError($"No existe el contacto con el id '{message.Id}'. Operación cancelada.");
                return CommandResponse;
            }

            existeUsuario.AddDomainEvent(new UsuarioEliminarEvent(existeUsuario.Id));

            _usuarioRepository.Eliminar(existeUsuario);

            CommandResponse.Data = null;
            CommandResponse.Result = true;

            return await Commit(_usuarioRepository.UnitOfWork);
        }
    }
}
