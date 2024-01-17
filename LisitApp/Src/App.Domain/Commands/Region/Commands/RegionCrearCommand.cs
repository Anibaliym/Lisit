using App.Domain.Commands.Region.Validations;
using App.Domain.Core.Messaging;

namespace App.Domain.Commands.Region.Commands
{
    public class RegionCrearCommand : RegionCommand
    {
        public RegionCrearCommand(Guid idPais, string nombre)
        {
            IdPais = IdPais;
            Nombre = nombre;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new RegionCrearCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
