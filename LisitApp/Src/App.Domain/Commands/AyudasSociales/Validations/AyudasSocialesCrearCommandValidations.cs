using App.Domain.Commands.AyudasSociales.Commands;

namespace App.Domain.Commands.AyudasSociales.Validations
{
    public class AyudasSocialesCrearCommandValidations : AyudasSocialesValidation<AyudasSocialesCrearCommand>
    {
        public AyudasSocialesCrearCommandValidations()
        {
            ValidaIdComuna();
            ValidaDescripcion();
            ValidaAnio();
        }
    }
}
