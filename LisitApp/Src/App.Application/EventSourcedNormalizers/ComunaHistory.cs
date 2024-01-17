using App.Domain.Core.Enumerations;
using App.Domain.Core.Events;
using Newtonsoft.Json;
using System.Web;

namespace App.Application.EventSourcedNormalizers
{
    public static class ComunaHistory
    {
        public static IList<ComunaHistoryData> HistoryData { get; set; }

        public static IList<ComunaHistoryData> ToJavaScriptCustomerHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<ComunaHistoryData>();
            UsuarioHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<ComunaHistoryData>();
            var last = new ComunaHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new ComunaHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id ? "" : change.Id,
                    IdRegion = change.IdRegion == Guid.Empty.ToString() || change.IdRegion == last.IdRegion ? "" : change.IdRegion,
                    Nombre = string.IsNullOrWhiteSpace(change.Nombre) || change.Nombre == last.Nombre ? "" : change.Nombre,


                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };

                jsSlot.Id = HttpUtility.HtmlEncode(jsSlot.Id);
                jsSlot.IdRegion = HttpUtility.HtmlEncode(jsSlot.IdRegion);
                jsSlot.Nombre = HttpUtility.HtmlEncode(jsSlot.Nombre);

                list.Add(jsSlot);
                last = change;
            }

            return list;
        }

        private static void UsuarioHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonConvert.DeserializeObject<ComunaHistoryData>(e.Data);

                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case "ComunaCrearEvent":
                        historyData.Action = HistoryDataEnum.REGISTERED.Name;
                        historyData.Who = e.User;
                        break;

                    case "ComunaModificarEvent":
                        historyData.Action = HistoryDataEnum.UPDATED.Name;
                        historyData.Who = e.User;
                        break;

                    case "ComunaEliminarEvent":
                        historyData.Action = HistoryDataEnum.REMOVED.Name;
                        historyData.Who = e.User;
                        break;

                    default:
                        historyData.Action = HistoryDataEnum.UNRECOGNIZED.Name;
                        historyData.Who = e.User ?? "Anonymous";
                        break;
                }

                HistoryData.Add(historyData);
            }
        }
    }
}
