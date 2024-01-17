using App.Domain.Core.Models;

namespace App.Application.EventSourcedNormalizers
{
    public class AyudasSocialesHistoryData : HistoryData
    {
        public string Id { get; set; } = string.Empty;
        public string IdComuna { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Anio { get; set; } = string.Empty;
    }
}
