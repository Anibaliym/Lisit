using System.ComponentModel;

namespace App.Application.ViewModels.Region
{
    public class RegionViewModel
    {
        [DisplayName("Identificador")]
        public Guid Id { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; } = string.Empty;
    }
}
