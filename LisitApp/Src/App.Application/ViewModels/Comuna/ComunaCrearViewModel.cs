using System.ComponentModel;

namespace App.Application.ViewModels.Comuna
{
    public class ComunaCrearViewModel
    {
        [DisplayName("Identificador del usuario gestionador")]
        public Guid IdUsuario { get; set; }


        [DisplayName("Identificador de la region")]
        public Guid IdRegion { get; set; }


        [DisplayName("Nombre")]
        public string Nombre { get; set; } = string.Empty;
    }
}
