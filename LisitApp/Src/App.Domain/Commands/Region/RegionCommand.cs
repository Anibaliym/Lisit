using App.Domain.Core.Messaging;

namespace App.Domain.Commands.Region
{
    public abstract class RegionCommand : Command
    {
        public Guid Id { get; set; }
        public Guid IdPais { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
