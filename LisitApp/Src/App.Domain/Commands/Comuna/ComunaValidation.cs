using FluentValidation;

namespace App.Domain.Commands.Comuna
{
    public abstract class ComunaValidation<T> : AbstractValidator<T> where T : ComunaCommand
    {
        protected void ValidaId()
        {
            RuleFor(comuna => comuna.Id)
                .NotEqual(Guid.Empty).WithMessage("El campo 'Id' es invalido")
                .NotEmpty().WithMessage("El campo 'Id' no puede ser vacío.");
        }

        protected void ValidaNombre()
        {
            RuleFor(comuna => comuna.Nombre).NotEmpty().WithMessage("El campo 'Nombre' no puede ser vacío.");
        }
    }
}
