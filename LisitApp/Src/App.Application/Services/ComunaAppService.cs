using App.Application.Interfaces;
using App.Application.ViewModels.Comuna;
using App.Domain.Commands.Comuna.Commands;
using App.Domain.Core.Mediator;
using App.Domain.Core.Messaging;
using App.Domain.Enumerations.Usuario;
using App.Domain.Interfaces;
using App.Infra.Data.Repository.EventSourcing;
using AutoMapper;

namespace App.Application.Services
{
    public class ComunaAppService : IComunaAppService
    {
        private readonly IMapper _mapper;
        private readonly IComunaRepository _comunaRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public ComunaAppService(IMapper mapper, IComunaRepository comunaRepository, IRegionRepository regionRepository, IUsuarioRepository usuarioRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _comunaRepository = comunaRepository;
            _regionRepository = regionRepository;
            _usuarioRepository = usuarioRepository;
            _eventStoreRepository = eventStoreRepository;
            _mediator = mediator;
        }

        public async Task<ComunaViewModel> BuscaPorId(Guid id)
        {
            return _mapper.Map<ComunaViewModel>(await _comunaRepository.BuscaPorId(id));
        }

        public async Task<ComunaViewModel> BuscaPorNombreComuna(string nombre)
        {
            return _mapper.Map<ComunaViewModel>(await _comunaRepository.BuscaPorNombreComuna(nombre));
        }

        //public async Task<CommandResponse> Crear(ComunaCrearViewModel modelo)
        //{
        //    var createCommand = _mapper.Map<ComunaCrearCommand>(modelo);
        //    return await _mediator.SendCommand(createCommand);
        //}

        public async Task<CommandResponse> Crear(ComunaCrearViewModel modelo)
        {
            CommandResponse response = new CommandResponse();
            CommandResponse crearComunaResponse = new CommandResponse();
            FluentValidation.Results.ValidationFailure item = new FluentValidation.Results.ValidationFailure();

            var existeRegion = await _regionRepository.BuscaPorId(modelo.IdRegion);
            var usuario = await _usuarioRepository.BuscaPorId(modelo.IdUsuario);

            if (usuario == null)
            {
                response.Result = false;
                item.ErrorMessage = $"El usuario con el id '{modelo.IdUsuario}', no existe. Operación canselada.";
                response.ValidationResult.Errors.Add(item);

                return response;
            }

            if (usuario.Rol != RolUsuarioEnum.ADMINISTRADOR.Name)
            {
                response.Result = false;
                item.ErrorMessage = $"El usuario con el id '{modelo.IdUsuario}', no posee permisos de usuario 'ADMINISTRADOR'. Operación canselada.";
                response.ValidationResult.Errors.Add(item);

                return response;
            }

            if (existeRegion == null)
            {
                item.ErrorMessage = $"La región con el id {modelo.IdRegion}, no existe. operación cancelada";

                response.Result = false;
                response.ValidationResult.Errors.Add(item);

                return response;
            }

            var createCommand = _mapper.Map<ComunaCrearCommand>(modelo);
            crearComunaResponse = await _mediator.SendCommand(createCommand);
            response = crearComunaResponse;

            return response;
        }

        //public async Task<CommandResponse> Eliminar(Guid id)
        //{
        //    var deleteCommand = new ComunaEliminarCommand(id);
        //    return await _mediator.SendCommand(deleteCommand);
        //}

        //public async Task<CommandResponse> Modificar(ComunaViewModel modelo)
        //{
        //    var updateCommand = _mapper.Map<ComunaModificarCommand>(modelo);
        //    return await _mediator.SendCommand(updateCommand);
        //}

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
