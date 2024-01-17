using App.Domain.Core.Enumerations;
using App.Domain.Core.Events;
using Newtonsoft.Json;
using System.Web;

namespace App.Application.EventSourcedNormalizers
{
    public static class AyudasSocialesHistory
    {
        public static IList<AyudasSocialesHistoryData> HistoryData { get; set; }

        public static IList<AyudasSocialesHistoryData> ToJavaScriptCustomerHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<AyudasSocialesHistoryData>();
            UsuarioHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<AyudasSocialesHistoryData>();
            var last = new AyudasSocialesHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new AyudasSocialesHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id ? "" : change.Id,
                    IdComuna = change.IdComuna == Guid.Empty.ToString() || change.IdComuna == last.IdComuna ? "" : change.IdComuna,
                    Descripcion = change.Descripcion == Guid.Empty.ToString() || change.Descripcion == last.Descripcion ? "" : change.Descripcion,
                    //Anio = string.IsNullOrWhiteSpace(change.Anio) || change.Anio == last.Anio ? "" : change.Anio.Substring(0, 10),



                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };

                jsSlot.Id = HttpUtility.HtmlEncode(jsSlot.Id);
                jsSlot.IdComuna = HttpUtility.HtmlEncode(jsSlot.IdComuna);
                jsSlot.Descripcion = HttpUtility.HtmlEncode(jsSlot.Descripcion);
                //jsSlot.Anio = HttpUtility.HtmlEncode(jsSlot.Anio);

                list.Add(jsSlot);
                last = change;
            }

            return list;
        }

        private static void UsuarioHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonConvert.DeserializeObject<AyudasSocialesHistoryData>(e.Data);

                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case "AyudasSocialesCrearEvent":
                        historyData.Action = HistoryDataEnum.REGISTERED.Name;
                        historyData.Who = e.User;
                        break;

                    case "AyudasSocialesModificarEvent":
                        historyData.Action = HistoryDataEnum.UPDATED.Name;
                        historyData.Who = e.User;
                        break;

                    case "AyudasSocialesEliminarEvent":
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
