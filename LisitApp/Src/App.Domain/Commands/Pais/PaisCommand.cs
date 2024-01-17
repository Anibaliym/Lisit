using App.Domain.Core.Messaging;

namespace App.Domain.Commands.Pais
{
    public abstract class PaisCommand : Command
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
