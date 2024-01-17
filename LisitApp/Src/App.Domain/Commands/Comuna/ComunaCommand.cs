using App.Domain.Core.Messaging;

namespace App.Domain.Commands.Comuna
{
    public abstract class ComunaCommand : Command
    {
        public Guid Id { get; set; }
        public Guid IdRegion { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
