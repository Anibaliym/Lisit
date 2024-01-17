using App.Domain.Commands.Usuario.Commands;
using App.Domain.Core.Messaging;
using App.Domain.Events.Usuario.Events;
using MediatR;

namespace App.Domain.Commands.Usuario.Handlers
{
    public partial class UsuarioCommandHandler : IRequestHandler<UsuarioModificarCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(UsuarioModificarCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var usuario = new Entities.Usuario(message.Id, message.Rut, message.Nombre, message.ApellidoPaterno, message.Contrasena, message.Rol);

            var existeusuario = await _usuarioRepository.BuscaPorId(message.Id);

            if (existeusuario == null)
            {
                AddError($"No existe el usuario con el id '{message.Id}'.");
                return CommandResponse;
            }


            usuario.AddDomainEvent(new UsuarioModificarEvent(
                usuario.Id, 
                usuario.Rut,
                usuario.Nombre, 
                usuario.ApellidoPaterno, 
                usuario.Contrasena, 
                usuario.Rol
            ));

            _usuarioRepository.Modificar(usuario);

            CommandResponse.Data = usuario;
            CommandResponse.Result = true;

            return await Commit(_usuarioRepository.UnitOfWork);
        }
    }
}
