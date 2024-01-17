using App.Domain.Commands.Pais.Commands;

namespace App.Domain.Commands.Pais.Validations
{
    public class PaisEliminarCommandValidations : PaisValidation<PaisEliminarCommand>
    {
        public PaisEliminarCommandValidations()
        {
            ValidaId();
        }
    }
}
