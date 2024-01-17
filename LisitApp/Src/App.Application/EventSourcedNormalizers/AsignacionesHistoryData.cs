using App.Domain.Core.Models;

namespace App.Application.EventSourcedNormalizers
{
    public class AsignacionesHistoryData : HistoryData
    {
        public string Id { get; set; } = string.Empty;
        public string idUsuario { get; set; } = string.Empty;
        public string idAyudaSocial { get; set; } = string.Empty;
        public string FechaAsignacion { get; set; } = string.Empty;
    }
}
