using App.Domain.Core.Enumerations;
using App.Domain.Core.Events;
using Newtonsoft.Json;
using System.Web;

namespace App.Application.EventSourcedNormalizers
{
    public static class RegionHistory
    {
        public static IList<RegionHistoryData> HistoryData { get; set; }

        public static IList<RegionHistoryData> ToJavaScriptCustomerHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<RegionHistoryData>();
            UsuarioHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<RegionHistoryData>();
            var last = new RegionHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new RegionHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id ? "" : change.Id,
                    IdPais = change.IdPais == Guid.Empty.ToString() || change.IdPais == last.IdPais ? "" : change.IdPais,
                    Nombre = string.IsNullOrWhiteSpace(change.Nombre) || change.Nombre == last.Nombre ? "" : change.Nombre,

                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };

                jsSlot.Id = HttpUtility.HtmlEncode(jsSlot.Id);
                jsSlot.IdPais = HttpUtility.HtmlEncode(jsSlot.IdPais);
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
                var historyData = JsonConvert.DeserializeObject<RegionHistoryData>(e.Data);

                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case "RegionCrearEvent":
                        historyData.Action = HistoryDataEnum.REGISTERED.Name;
                        historyData.Who = e.User;
                        break;

                    case "RegionModificarEvent":
                        historyData.Action = HistoryDataEnum.UPDATED.Name;
                        historyData.Who = e.User;
                        break;

                    case "RegionEliminarEvent":
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
