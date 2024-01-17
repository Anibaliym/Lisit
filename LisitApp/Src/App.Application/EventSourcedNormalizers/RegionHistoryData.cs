using App.Domain.Core.Models;

namespace App.Application.EventSourcedNormalizers
{
    public class RegionHistoryData : HistoryData
    {
        public string Id { get; set; } = string.Empty;
        public string IdPais { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
    }
}
