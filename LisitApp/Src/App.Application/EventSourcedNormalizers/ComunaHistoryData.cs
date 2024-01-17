using App.Domain.Core.Models;

namespace App.Application.EventSourcedNormalizers
{
    public class ComunaHistoryData : HistoryData
    {
        public string Id { get; set; } = string.Empty;
        public string IdRegion { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
    }
}
