using App.Domain.Commands.Usuario.Commands;

namespace App.Domain.Commands.Usuario.Validations
{
    public class UsuarioEliminarCommandValidations : UsuarioValidation<UsuarioEliminarCommand>
    {
        public UsuarioEliminarCommandValidations()
        {
            ValidaId();
        }
    }
}
