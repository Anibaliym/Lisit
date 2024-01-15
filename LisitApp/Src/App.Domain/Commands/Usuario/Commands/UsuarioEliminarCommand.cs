using App.Domain.Commands.Usuario.Validations;
using App.Domain.Core.Messaging;

namespace App.Domain.Commands.Usuario.Commands
{
    public class UsuarioEliminarCommand : UsuarioCommand
    {
        public UsuarioEliminarCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new UsuarioEliminarCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
