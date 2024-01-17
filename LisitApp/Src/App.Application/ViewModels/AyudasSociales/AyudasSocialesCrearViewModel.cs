using System.ComponentModel;

namespace App.Application.ViewModels.AyudasSociales
{
    public class AyudasSocialesCrearViewModel
    {
        [DisplayName("Identificador de la comuna")]
        public Guid IdComuna { get; set; }

        [DisplayName("Descripción de la ayuda")]
        public string Descripcion { get; set; } = string.Empty;

        [DisplayName("Año de la ayuda")]
        public int Anio { get; set; }
    }
}
