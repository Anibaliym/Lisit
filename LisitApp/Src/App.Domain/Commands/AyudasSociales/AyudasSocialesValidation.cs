using FluentValidation;

namespace App.Domain.Commands.AyudasSociales
{
    public abstract class AyudasSocialesValidation<T> : AbstractValidator<T> where T : AyudasSocialesCommand
    {
        protected void ValidaId()
        {
            RuleFor(item => item.Id)
                .NotEqual(Guid.Empty).WithMessage("El campo 'Id' es invalido")
                .NotEmpty().WithMessage("El campo 'Id' no puede ser vacío.");
        }

        protected void ValidaIdComuna()
        {
            RuleFor(item => item.IdComuna)
                .NotEqual(Guid.Empty).WithMessage("El campo 'IdComuna' es invalido")
                .NotEmpty().WithMessage("El campo 'IdComuna' no puede ser vacío.");
        }

        protected void ValidaDescripcion()
        {
            RuleFor(item => item.Descripcion).NotEmpty().WithMessage("El campo 'Descripcion' no puede ser vacío.");
        }

        protected void ValidaAnio()
        {
            RuleFor(item => item.Anio).NotEmpty().WithMessage("El campo 'Anio' no puede ser vacío.");
        }
    }
}
