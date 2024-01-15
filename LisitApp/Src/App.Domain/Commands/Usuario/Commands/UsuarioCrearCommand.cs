using App.Domain.Commands.Usuario.Validations;

namespace App.Domain.Commands.Usuario.Commands
{
    public class UsuarioCrearCommand : UsuarioCommand
    {
        public UsuarioCrearCommand(string rut, string nombre, string apellidoPaterno, string contrasena, string rol)
        {
            Rut = rut;
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            Contrasena = contrasena;
            Rol = rol;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new UsuarioCrearCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
