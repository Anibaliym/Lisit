using App.Domain.Core.Messaging;

namespace App.Domain.Commands.AyudasSociales
{
    public abstract class AyudasSocialesCommand : Command
    {
        public Guid Id { get; set; }
        public Guid IdComuna { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int Anio { get; set; }
    }
}
