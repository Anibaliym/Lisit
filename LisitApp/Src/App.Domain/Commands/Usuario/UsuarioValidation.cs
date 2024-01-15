using App.Domain.Commands.CommonValidators.Validators;
using App.Domain.Enumerations.Usuario;
using FluentValidation;

namespace App.Domain.Commands.Usuario
{
    public abstract class UsuarioValidation<T> : AbstractValidator<T> where T : UsuarioCommand
    {
        protected void ValidaId()
        {
            RuleFor(usuario => usuario.Id)
                .NotEqual(Guid.Empty).WithMessage("El campo 'Id' es invalido")
                .NotEmpty().WithMessage("El campo 'Id' no puede ser vacío.");
        }

        protected void ValidaRut()
        {
            RuleFor(usuario => usuario.Rut)
                .NotEmpty().WithMessage("El campo 'Rut' no puede ser vacío.")
                .MinimumLength(7).WithMessage("El rut debe contener al menos 7 caracteres.")
                .MaximumLength(8).WithMessage("El rut debe contener hasta 8 caracteres.")
            ;
        }

        protected void ValidaNombre()
        {
            RuleFor(usuario => usuario.Nombre).NotEmpty().WithMessage("El campo 'Nombre' no puede ser vacío.")
                .MinimumLength(5).WithMessage("El campo 'Nombre' debe contener al menos 5 caracteres.")
                .MaximumLength(8).WithMessage("El campo 'Nombre' debe contener como máximo 200 caracteres.")
            ;
        }

        protected void ValidaApellidoPaterno()
        {
            RuleFor(usuario => usuario.ApellidoPaterno).NotEmpty().WithMessage("El campo 'ApellidoPaterno' no puede ser vacío.")
                .MinimumLength(5).WithMessage("El campo 'ApellidoPaterno' debe contener al menos 5 caracteres.")
                .MaximumLength(8).WithMessage("El campo 'ApellidoPaterno' debe contener como máximo 200 caracteres.")
            ;
        }

        protected void ValidaContrasena()
        {
            RuleFor(usuario => usuario.Contrasena).NotEmpty().WithMessage("El campo 'Contraseña' no puede ser vacío.")
                .MinimumLength(6).WithMessage("El campo 'Contraseña' debe contener al menos 6 caracteres.")
                .MaximumLength(20).WithMessage("El campo 'Contraseña' debe contener como máximo 20 caracteres.")
            ;
        }

        protected void ValidaRol()
        {
            RuleFor(usuario => usuario.Rol)
                .NotEmpty().WithMessage("El campo 'Rol' no puede ser vacío.")
                .Must(CommonValidator.ValidadorDeEnumeraciones<RolUsuarioEnum>).WithMessage("El 'Rol' debe estar entre los valores permitidos ('ADMINISTRADOR','USUARIO').");
        }
    }
}
