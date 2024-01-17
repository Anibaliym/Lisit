using FluentValidation;

namespace App.Domain.Commands.Asignaciones
{
    public abstract class AsignacionesValidation<T> : AbstractValidator<T> where T : AsignacionesCommand
    {
        protected void ValidaId()
        {
            RuleFor(asignaciones => asignaciones.Id)
                .NotEqual(Guid.Empty).WithMessage("El campo 'Id' es invalido")
                .NotEmpty().WithMessage("El campo 'Id' no puede ser vacío.");
        }

        protected void ValidaIdUsuario()
        {
            RuleFor(asignaciones => asignaciones.IdUsuario)
                .NotEqual(Guid.Empty).WithMessage("El campo 'IdUsuario' es invalido")
                .NotEmpty().WithMessage("El campo 'IdUsuario' no puede ser vacío.");
        }
        protected void ValidaIdAyudaSocial()
        {
            RuleFor(asignaciones => asignaciones.IdAyudaSocial)
                .NotEqual(Guid.Empty).WithMessage("El campo 'IdAyudaSocial' es invalido")
                .NotEmpty().WithMessage("El campo 'IdAyudaSocial' no puede ser vacío.");
        }

        protected void ValidaFechaAsignacion()
        {
            RuleFor(asignaciones => asignaciones.FechaAsignacion).NotEmpty().WithMessage("El campo 'FechaAsignacion' no puede ser vacío.");
        }
    }
}
