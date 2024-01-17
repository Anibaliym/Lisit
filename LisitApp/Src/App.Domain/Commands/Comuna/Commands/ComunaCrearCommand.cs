using App.Domain.Commands.Comuna.Validations;
using App.Domain.Core.Messaging;

namespace App.Domain.Commands.Comuna.Commands
{
    public class ComunaCrearCommand : ComunaCommand
    {
        public ComunaCrearCommand(Guid idRegion, string nombre)
        {
            IdRegion = idRegion; 
            Nombre = nombre;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new ComunaCrearCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
