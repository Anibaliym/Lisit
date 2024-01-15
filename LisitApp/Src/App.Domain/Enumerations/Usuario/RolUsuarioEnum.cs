using Ardalis.SmartEnum;

namespace App.Domain.Enumerations.Usuario
{
    public sealed class RolUsuarioEnum : SmartEnum<RolUsuarioEnum>
    {
        public static readonly RolUsuarioEnum ADMINISTRADOR = new("ADMINISTRADOR", 1);
        public static readonly RolUsuarioEnum USUARIO = new("ADMINISTRADOR", 2);

        private RolUsuarioEnum(string name, int value) : base(name, value) { }
    }
}
