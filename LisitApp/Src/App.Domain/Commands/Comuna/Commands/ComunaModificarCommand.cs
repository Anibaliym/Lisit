using App.Domain.Core.Messaging;
using App.Domain.Commands.Comuna.Validations;

namespace App.Domain.Commands.Comuna.Commands
{
    public class ComunaModificarCommand : ComunaCommand
    {
        public ComunaModificarCommand(Guid id, Guid idRegion, string nombre)
        {
            Id = id;
            IdRegion = idRegion;
            Nombre = nombre;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new ComunaModificarCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
