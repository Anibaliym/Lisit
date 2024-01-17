using App.Domain.Core.Messaging;
using App.Domain.Commands.Pais.Validations;

namespace App.Domain.Commands.Pais.Commands
{
    public class PaisModificarCommand : PaisCommand
    {
        public PaisModificarCommand(Guid id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new PaisModificarCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
