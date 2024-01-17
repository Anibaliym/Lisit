using App.Domain.Commands.Comuna.Commands;

namespace App.Domain.Commands.Comuna.Validations
{
    public class ComunaModificarCommandValidations : ComunaValidation<ComunaModificarCommand>
    {
        public ComunaModificarCommandValidations()
        {
            ValidaId();
            ValidaNombre();
        }
    }
}
