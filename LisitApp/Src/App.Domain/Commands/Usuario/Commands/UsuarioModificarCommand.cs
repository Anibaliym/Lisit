using App.Domain.Commands.Usuario.Validations;
using App.Domain.Core.Messaging;

namespace App.Domain.Commands.Usuario.Commands
{
    public class UsuarioModificarCommand : UsuarioCommand
    {
        public UsuarioModificarCommand(Guid id, string rut, string nombre, string apellidoPaterno, string contrasena, string rol)
        {
            Id = id;
            Rut = rut;
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            Contrasena = contrasena;
            Rol = rol;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new UsuarioModificarCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
