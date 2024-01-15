using Newtonsoft.Json;
using App.Domain.Core.Enumerations;
using App.Domain.Core.Events;
using System.Web;

namespace App.Application.EventSourcedNormalizers.Usuario
{
    public static class UsuarioHistory
    {
        public static IList<UsuarioHistoryData> HistoryData { get; set; }

        public static IList<UsuarioHistoryData> ToJavaScriptCustomerHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<UsuarioHistoryData>();
            UsuarioHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<UsuarioHistoryData>();
            var last = new UsuarioHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new UsuarioHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id ? "" : change.Id,
                    Rut = string.IsNullOrWhiteSpace(change.Rut) || change.Rut == last.Rut ? "" : change.Rut,
                    Nombre = string.IsNullOrWhiteSpace(change.Nombre) || change.Nombre == last.Nombre ? "" : change.Nombre,
                    ApellidoPaterno = string.IsNullOrWhiteSpace(change.ApellidoPaterno) || change.ApellidoPaterno == last.ApellidoPaterno ? "" : change.ApellidoPaterno,
                    Contrasena = string.IsNullOrWhiteSpace(change.Contrasena) || change.Contrasena == last.Contrasena ? "" : change.Contrasena,
                    Rol = string.IsNullOrWhiteSpace(change.Rol) || change.Rol == last.Rol ? "" : change.Rol,

                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };

                jsSlot.Id = HttpUtility.HtmlEncode(jsSlot.Id);
                jsSlot.Rut = HttpUtility.HtmlEncode(jsSlot.Rut);
                jsSlot.Nombre = HttpUtility.HtmlEncode(jsSlot.Nombre);
                jsSlot.ApellidoPaterno = HttpUtility.HtmlEncode(jsSlot.ApellidoPaterno);
                jsSlot.Contrasena = HttpUtility.HtmlEncode(jsSlot.Contrasena);
                jsSlot.Rol = HttpUtility.HtmlEncode(jsSlot.Rol);

                list.Add(jsSlot);
                last = change;
            }

            return list;
        }

        private static void UsuarioHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonConvert.DeserializeObject<UsuarioHistoryData>(e.Data);

                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case "UsuarioCrearEvent":
                        historyData.Action = HistoryDataEnum.REGISTERED.Name;
                        historyData.Who = e.User;
                        break;

                    case "UsuarioModificarEvent":
                        historyData.Action = HistoryDataEnum.UPDATED.Name;
                        historyData.Who = e.User;
                        break;

                    case "UsuarioEliminarEvent":
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