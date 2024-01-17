using App.Domain.Commands.Region.Commands;

namespace App.Domain.Commands.Region.Validations
{
    public class RegionCrearCommandValidations : RegionValidation<RegionCrearCommand>
    {
        public RegionCrearCommandValidations()
        {
            ValidaNombre();
        }
    }
}
