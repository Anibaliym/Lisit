using App.Domain.Core.Messaging;
using App.Domain.Commands.Comuna.Validations;

namespace App.Domain.Commands.Comuna.Commands
{
    public class ComunaEliminarCommand : ComunaCommand
    {
        public ComunaEliminarCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new ComunaEliminarCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
