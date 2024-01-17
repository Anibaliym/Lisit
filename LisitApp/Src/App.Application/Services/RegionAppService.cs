using App.Application.Interfaces;
using App.Application.ViewModels.Region;
using App.Domain.Commands.Region.Commands;
using App.Domain.Core.Mediator;
using App.Domain.Core.Messaging;
using App.Domain.Enumerations.Usuario;
using App.Domain.Interfaces;
using App.Infra.Data.Repository.EventSourcing;
using AutoMapper;

namespace App.Application.Services
{
    public class RegionAppService : IRegionAppService
    {
        private readonly IMapper _mapper;
        private readonly IRegionRepository _regionRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPaisRepository _paisRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public RegionAppService(IMapper mapper, IRegionRepository regionRepository, IPaisRepository paisRepository, IUsuarioRepository usuarioRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _regionRepository = regionRepository;
            _paisRepository = paisRepository;
            _usuarioRepository = usuarioRepository;
            _eventStoreRepository = eventStoreRepository;
            _mediator = mediator;
        }

        public async Task<RegionViewModel> BuscaPorId(Guid id)
        {
            return _mapper.Map<RegionViewModel>(await _regionRepository.BuscaPorId(id));
        }

        public async Task<RegionViewModel> BuscaPorNombreRegion(string nombre)
        {
            return _mapper.Map<RegionViewModel>(await _regionRepository.BuscaPorNombreRegion(nombre));
        }

        public async Task<CommandResponse> Crear(RegionCrearViewModel modelo)
        {
            CommandResponse response = new CommandResponse();
            CommandResponse crearRegionResponse = new CommandResponse();
            FluentValidation.Results.ValidationFailure item = new FluentValidation.Results.ValidationFailure();

            var existePais = await _paisRepository.BuscaPorId(modelo.IdPais);
            var usuario = await _usuarioRepository.BuscaPorId(modelo.IdUsuario);

            if (usuario == null) {
                response.Result = false;
                item.ErrorMessage = $"El usuario con el id '{modelo.IdUsuario}', no existe. Operación canselada.";
                response.ValidationResult.Errors.Add(item);

                return response;
            }

            if (usuario.Rol != RolUsuarioEnum.ADMINISTRADOR.Name) {
                response.Result = false;
                item.ErrorMessage = $"El usuario con el id '{modelo.IdUsuario}', no posee permisos de usuario 'ADMINISTRADOR'. Operación canselada.";
                response.ValidationResult.Errors.Add(item);

                return response;
            }

            if (existePais == null) {
                item.ErrorMessage = $"El País con el id {modelo.IdPais}, no existe. operación cancelada";

                response.Result = false;
                response.ValidationResult.Errors.Add(item);

                return response;
            }

            var createCommand = _mapper.Map<RegionCrearCommand>(modelo);
            crearRegionResponse = await _mediator.SendCommand(createCommand);
            response = crearRegionResponse;

            return response; 
        }

        //public async Task<CommandResponse> Eliminar(Guid id)
        //{
        //    var deleteCommand = new RegionEliminarCommand(id);
        //    return await _mediator.SendCommand(deleteCommand);
        //}

        //public async Task<CommandResponse> Modificar(RegionViewModel modelo)
        //{
        //    var updateCommand = _mapper.Map<RegionModificarCommand>(modelo);
        //    return await _mediator.SendCommand(updateCommand);
        //}

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
