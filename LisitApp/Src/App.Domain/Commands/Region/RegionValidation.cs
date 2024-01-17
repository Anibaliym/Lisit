using FluentValidation;

namespace App.Domain.Commands.Region
{
    public abstract class RegionValidation<T> : AbstractValidator<T> where T : RegionCommand
    {
        protected void ValidaId()
        {
            RuleFor(region => region.Id)
                .NotEqual(Guid.Empty).WithMessage("El campo 'Id' es invalido")
                .NotEmpty().WithMessage("El campo 'Id' no puede ser vacío.");
        }

        protected void ValidaIdPais()
        {
            RuleFor(region => region.IdPais)
                .NotEqual(Guid.Empty).WithMessage("El campo 'IdPais' es invalido")
                .NotEmpty().WithMessage("El campo 'IdPais' no puede ser vacío.");
        }

        protected void ValidaNombre()
        {
            RuleFor(region => region.Nombre).NotEmpty().WithMessage("El campo 'Nombre' no puede ser vacío.");
        }
    }
}
