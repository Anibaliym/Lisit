using App.Domain.Commands.Asignaciones.Validations;
using App.Domain.Core.Messaging;

namespace App.Domain.Commands.Asignaciones.Commands
{
    public class AsignacionesCrearCommand : AsignacionesCommand
    {
        public AsignacionesCrearCommand(Guid idUsuario, Guid idAyudaSocial, DateTime fechaAsignacion)
        {
            IdUsuario = idUsuario;
            IdAyudaSocial = idAyudaSocial;
            FechaAsignacion = fechaAsignacion;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new AsignacionesCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
