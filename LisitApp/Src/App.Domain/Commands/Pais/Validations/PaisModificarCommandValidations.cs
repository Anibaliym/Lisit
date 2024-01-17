using App.Domain.Commands.Pais.Commands;

namespace App.Domain.Commands.Pais.Validations
{
    public class PaisModificarCommandValidations : PaisValidation<PaisModificarCommand>
    {
        public PaisModificarCommandValidations()
        {
            ValidaId();
            ValidaNombre();
        }
    }
}
