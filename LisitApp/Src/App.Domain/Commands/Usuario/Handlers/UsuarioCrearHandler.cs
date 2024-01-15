using App.Domain.Commands.Usuario.Commands;
using App.Domain.Core.Messaging;
using App.Domain.Events.Usuario.Events;
using MediatR;

namespace App.Domain.Commands.Usuario.Handlers
{
    public partial class UsuarioCommandHandler : IRequestHandler<UsuarioCrearCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(UsuarioCrearCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var usuario = new Entities.Usuario(Guid.NewGuid(), message.Rut, message.Nombre, message.ApellidoPaterno, message.Contrasena, message.Rol);

            var existeUsuario = await _usuarioRepository.BuscaPorRut(message.Rut);

            if (existeUsuario != null)
            {
                AddError($"Ya un usuario con el rut '{message.Rut}'. Operación Cancelada");
                return CommandResponse;
            }

            usuario.AddDomainEvent(new UsuarioCrearEvent(
                usuario.Id,
                usuario.Rut,
                message.Nombre,
                message.ApellidoPaterno,
                message.Contrasena,
                message.Rol
            ));

            _usuarioRepository.Crear(usuario);

            CommandResponse.Data = usuario;
            CommandResponse.Result = true;

            return await Commit(_usuarioRepository.UnitOfWork);

        }
    }
}
