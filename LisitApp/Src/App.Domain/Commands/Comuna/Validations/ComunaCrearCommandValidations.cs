using App.Domain.Commands.Comuna.Commands;

namespace App.Domain.Commands.Comuna.Validations
{
    public class ComunaCrearCommandValidations : ComunaValidation<ComunaCrearCommand>
    {
        public ComunaCrearCommandValidations()
        {
            ValidaNombre();
        }
    }
}
