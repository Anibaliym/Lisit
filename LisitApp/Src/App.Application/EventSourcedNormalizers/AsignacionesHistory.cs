using App.Domain.Core.Enumerations;
using App.Domain.Core.Events;
using Newtonsoft.Json;
using System.Web;

namespace App.Application.EventSourcedNormalizers
{
    public static class AsignacionesHistory
    {
        public static IList<AsignacionesHistoryData> HistoryData { get; set; }

        public static IList<AsignacionesHistoryData> ToJavaScriptCustomerHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<AsignacionesHistoryData>();
            UsuarioHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<AsignacionesHistoryData>();
            var last = new AsignacionesHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new AsignacionesHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id ? "" : change.Id,
                    idUsuario = change.idUsuario == Guid.Empty.ToString() || change.idUsuario == last.idUsuario ? "" : change.idUsuario,
                    idAyudaSocial = change.idAyudaSocial == Guid.Empty.ToString() || change.idAyudaSocial == last.idAyudaSocial ? "" : change.idAyudaSocial,
                    FechaAsignacion = string.IsNullOrWhiteSpace(change.FechaAsignacion) || change.FechaAsignacion == last.FechaAsignacion ? "" : change.FechaAsignacion.Substring(0, 10),



                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };

                jsSlot.Id = HttpUtility.HtmlEncode(jsSlot.Id);
                jsSlot.idUsuario = HttpUtility.HtmlEncode(jsSlot.idUsuario);
                jsSlot.idAyudaSocial = HttpUtility.HtmlEncode(jsSlot.idAyudaSocial);
                jsSlot.FechaAsignacion = HttpUtility.HtmlEncode(jsSlot.FechaAsignacion);

                list.Add(jsSlot);
                last = change;
            }

            return list;
        }

        private static void UsuarioHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonConvert.DeserializeObject<AsignacionesHistoryData>(e.Data);

                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case "AsignacionesCrearEvent":
                        historyData.Action = HistoryDataEnum.REGISTERED.Name;
                        historyData.Who = e.User;
                        break;

                    case "AsignacionesModificarEvent":
                        historyData.Action = HistoryDataEnum.UPDATED.Name;
                        historyData.Who = e.User;
                        break;

                    case "AsignacionesEliminarEvent":
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
