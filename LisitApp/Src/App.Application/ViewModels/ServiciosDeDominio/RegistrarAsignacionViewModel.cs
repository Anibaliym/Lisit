using App.Application.ViewModels.Asignaciones;
using System.ComponentModel;

namespace App.Application.ViewModels.ServiciosDeDominio
{
    public class RegistrarAsignacionViewModel
    {
        [DisplayName("Identificador del usuario gestionador")]
        public Guid IdUsuario { get; set; }

        [DisplayName("Información de la asignación")]
        public AsignacionesCrearViewModel? Asignacion { get; set; }
    }
}
