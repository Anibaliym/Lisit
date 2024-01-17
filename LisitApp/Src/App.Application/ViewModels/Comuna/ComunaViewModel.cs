using System.ComponentModel;

namespace App.Application.ViewModels.Comuna
{
    public class ComunaViewModel
    {
        [DisplayName("Identificador")]
        public Guid Id { get; set; }

        [DisplayName("Identificador de la región")]
        public Guid IdRegion { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; } = string.Empty;
    }
}
