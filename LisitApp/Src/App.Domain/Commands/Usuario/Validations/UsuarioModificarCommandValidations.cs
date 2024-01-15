using App.Domain.Commands.Usuario.Commands;

namespace App.Domain.Commands.Usuario.Validations
{
    public class UsuarioModificarCommandValidations : UsuarioValidation<UsuarioModificarCommand>
    {
        public UsuarioModificarCommandValidations()
        {
            ValidaId();
            ValidaRut();
            ValidaNombre();
            ValidaApellidoPaterno();
            ValidaContrasena();
            ValidaRol();
        }
    }
}
