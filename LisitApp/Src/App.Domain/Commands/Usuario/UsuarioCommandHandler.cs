using App.Domain.Core.Messaging;
using App.Domain.Interfaces;

namespace App.Domain.Commands.Usuario.Handlers
{
    public partial class UsuarioCommandHandler : CommandHandler
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioCommandHandler(IUsuarioRepository accionRepository)
        {
            _usuarioRepository = accionRepository ?? throw new ArgumentNullException(nameof(accionRepository));
        }
    }
}
