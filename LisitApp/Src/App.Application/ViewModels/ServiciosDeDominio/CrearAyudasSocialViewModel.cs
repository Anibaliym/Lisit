using App.Application.ViewModels.AyudasSociales;
using System.ComponentModel;

namespace App.Application.ViewModels.ServiciosDeDominio
{
    public class CrearAyudasSocialViewModel
    {
        [DisplayName("Identificador del usuario gestionador")]
        public Guid IdUsuario { get; set; }

        [DisplayName("Información de la ayuda social")]
        public AyudasSocialesCrearViewModel? AyudasSociales { get; set; }
    }
}
