using App.Domain.Core.Messaging;
using App.Domain.Commands.Pais.Validations;

namespace App.Domain.Commands.Pais.Commands
{
    public class PaisCrearCommand : PaisCommand
    {
        public PaisCrearCommand(string nombre)
        {
            Nombre = nombre;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new PaisCrearCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
