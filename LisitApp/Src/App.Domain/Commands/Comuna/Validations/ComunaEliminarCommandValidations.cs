using App.Domain.Commands.Comuna.Commands;

namespace App.Domain.Commands.Comuna.Validations
{
    public class ComunaEliminarCommandValidations : ComunaValidation<ComunaEliminarCommand>
    {
        public ComunaEliminarCommandValidations()
        {
            ValidaId();
        }
    }
}
