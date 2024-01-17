using App.Domain.Commands.Pais.Commands;

namespace App.Domain.Commands.Pais.Validations
{
    public class PaisCrearCommandValidations : PaisValidation<PaisCrearCommand>
    {
        public PaisCrearCommandValidations()
        {
            ValidaNombre();
        }
    }
}
