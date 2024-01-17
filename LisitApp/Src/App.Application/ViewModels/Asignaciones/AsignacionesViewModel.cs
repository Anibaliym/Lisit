using System.ComponentModel;

namespace App.Application.ViewModels.Asignaciones
{
    public class AsignacionesViewModel
    {
        [DisplayName("Identificador")]
        public Guid Id { get; set; }

        [DisplayName("Identificador del usuario")]
        public Guid IdUsuario { get; set; }

        [DisplayName("Identificador de la ayuda social")]
        public Guid IdAyudaSocial { get; set; }

        [DisplayName("Fecha de asignación")]
        public DateTime FechaAsignacion { get; set; }
    }
}
