using App.Domain.Commands.Usuario.Commands;

namespace App.Domain.Commands.Usuario.Validations
{
    public class UsuarioCrearCommandValidations : UsuarioValidation<UsuarioCrearCommand>
    {
        public UsuarioCrearCommandValidations()
        {
            ValidaRut(); 
            ValidaNombre();
            ValidaApellidoPaterno();
            ValidaContrasena();
            //ValidaRol();
        }
    }
}
