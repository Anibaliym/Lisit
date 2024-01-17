using App.Domain.Commands.AyudasSociales.Validations;
using App.Domain.Core.Messaging;

namespace App.Domain.Commands.AyudasSociales.Commands
{
    public class AyudasSocialesCrearCommand : AyudasSocialesCommand
    {
        public AyudasSocialesCrearCommand(Guid idComuna, string descripcion, int anio)
        {
            IdComuna = idComuna;
            Descripcion = descripcion;
            Anio = anio;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new AyudasSocialesCrearCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
