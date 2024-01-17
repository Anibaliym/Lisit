using System.ComponentModel;

namespace App.Application.ViewModels.Pais
{
    public class PaisCrearViewModel
    {
        [DisplayName("IdUsuario")]
        public Guid IdUsuario { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; } = string.Empty;
    }
}
