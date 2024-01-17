using App.Domain.Commands.Pais.Validations;
using App.Domain.Core.Messaging;

namespace App.Domain.Commands.Pais.Commands
{
    public class PaisEliminarCommand : PaisCommand
    {
        public PaisEliminarCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new PaisEliminarCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
