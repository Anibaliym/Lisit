using App.Domain.Commands.Asignaciones.Commands;

namespace App.Domain.Commands.Asignaciones.Validations
{
    public class AsignacionesCommandValidations : AsignacionesValidation<AsignacionesCrearCommand>
    {
        public AsignacionesCommandValidations()
        {
            ValidaIdUsuario();
            ValidaIdAyudaSocial();
            ValidaFechaAsignacion();
        }
    }
}
