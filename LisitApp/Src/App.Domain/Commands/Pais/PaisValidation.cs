using App.Domain.Commands.Comuna;
using FluentValidation;

namespace App.Domain.Commands.Pais
{
    public abstract class PaisValidation<T> : AbstractValidator<T> where T : PaisCommand
    {
        protected void ValidaId()
        {
            RuleFor(pais => pais.Id)
                .NotEqual(Guid.Empty).WithMessage("El campo 'Id' es invalido")
                .NotEmpty().WithMessage("El campo 'Id' no puede ser vacío.");
        }

        protected void ValidaNombre()
        {
            RuleFor(pais => pais.Nombre).NotEmpty().WithMessage("El campo 'Nombre' no puede ser vacío.");
        }
    }
}
