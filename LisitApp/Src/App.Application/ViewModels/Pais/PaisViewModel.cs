using System.ComponentModel;

namespace App.Application.ViewModels.Pais
{
    public class PaisViewModel
    {
        [DisplayName("Identificador")]
        public Guid Id { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; } = string.Empty;
    }
}
