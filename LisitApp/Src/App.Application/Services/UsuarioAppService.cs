using App.Application.Interfaces;
using App.Application.ViewModels.Usuario;
using App.Domain.Commands.Usuario.Commands;
using App.Domain.Core.Mediator;
using App.Domain.Core.Messaging;
using App.Domain.Interfaces;
using App.Infra.Data.Repository.EventSourcing;
using AutoMapper;

namespace App.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public UsuarioAppService(IMapper mapper, IUsuarioRepository usuarioRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _eventStoreRepository = eventStoreRepository;
            _mediator = mediator;
        }

        public async Task<UsuarioViewModel> BuscaPorId(Guid id)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.BuscaPorId(id));

        }

        public async Task<UsuarioViewModel> BuscaPorRut(string rut)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.BuscaPorRut(rut));
        }

        public async Task<CommandResponse> Crear(UsuarioCrearViewModel modelo)
        {
            var createCommand = _mapper.Map<UsuarioCrearCommand>(modelo);
            return await _mediator.SendCommand(createCommand);
        }

        public async Task<CommandResponse> Eliminar(Guid id)
        {
            var deleteCommand = new UsuarioEliminarCommand(id);
            return await _mediator.SendCommand(deleteCommand);
        }

        public async Task<CommandResponse> Modificar(UsuarioModificarViewModel modelo)
        {
            var updateCommand = _mapper.Map<UsuarioModificarCommand>(modelo);
            return await _mediator.SendCommand(updateCommand);
        }
        public async Task<CommandResponse> LoginUsuario(string rut, string contrasena)
        {
            CommandResponse response = new();

            var informacionUsuario = await _usuarioRepository.LoginUsuario(rut, contrasena);

            if (informacionUsuario != null)
            {
                response.Result = true;

                response.Data = new
                {
                    Acceso = true,
                    DatosUsuario = new
                    {
                        Nombre = informacionUsuario.Nombre,
                        ApellidoPaterno = informacionUsuario.ApellidoPaterno,
                        Rol = informacionUsuario.Rol
                    },
                    Info = "Acceso Permisito"
                };
            }
            else
            {
                response.Result = true;

                response.Data = new
                {
                    Acceso = false,
                    DatosUsuario = new { },
                    Info = "Acceso Denegado. El rut y la contraseña con coinciden."
                };
            }

            return response; 
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
