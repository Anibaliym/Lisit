using System.ComponentModel;

namespace App.Application.ViewModels.Region
{
    public class RegionCrearViewModel
    {
        [DisplayName("IdUsuario")]
        public Guid IdUsuario { get; set; }

        [DisplayName("Identificador del pais")]
        public Guid IdPais { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; } = string.Empty;
    }
}
