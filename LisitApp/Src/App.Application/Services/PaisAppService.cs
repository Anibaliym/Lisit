using App.Application.EventSourcedNormalizers;
using App.Application.Interfaces;
using App.Application.ViewModels.Pais;
using App.Domain.Commands.Pais.Commands;
using App.Domain.Core.Mediator;
using App.Domain.Core.Messaging;
using App.Domain.Enumerations.Usuario;
using App.Domain.Interfaces;
using App.Infra.Data.Repository.EventSourcing;
using AutoMapper;

namespace App.Application.Services
{
    public class PaisAppService : IPaisAppService
    {
        private readonly IMapper _mapper;
        private readonly IPaisRepository _paisRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public PaisAppService(IMapper mapper, IPaisRepository paisRepository, IUsuarioRepository usuarioRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _paisRepository = paisRepository;
            _usuarioRepository = usuarioRepository;
            _eventStoreRepository = eventStoreRepository;
            _mediator = mediator;
        }

        public async Task<PaisViewModel> BuscaPorId(Guid id)
        {
            return _mapper.Map<PaisViewModel>(await _paisRepository.BuscaPorId(id));
        }

        public async Task<PaisViewModel> BuscaPorNombrePais(string nombre)
        {
            return _mapper.Map<PaisViewModel>(await _paisRepository.BuscaPorNombrePais(nombre));
        }

        public async Task<CommandResponse> Crear(PaisCrearViewModel modelo)
        {
            FluentValidation.Results.ValidationFailure item = new FluentValidation.Results.ValidationFailure();
            CommandResponse response = new CommandResponse();
            CommandResponse responseCrearPais = new CommandResponse();

            var usuario = await _usuarioRepository.BuscaPorId(modelo.IdUsuario);

            if (usuario != null)
            {
                if (usuario.Rol != RolUsuarioEnum.ADMINISTRADOR.Name) {
                    response.Result = false;
                    item.ErrorMessage = $"El usuario con el id '{modelo.IdUsuario}', no posee permisos de usuario 'ADMINISTRADOR'. Operación canselada.";
                    response.ValidationResult.Errors.Add(item);

                    return response;
                }

                var createCommand = _mapper.Map<PaisCrearCommand>(modelo);
                responseCrearPais = await _mediator.SendCommand(createCommand);

                response = responseCrearPais;
            }
            else
            {
                response.Result = false;
                item.ErrorMessage = $"El usuario con el id '{modelo.IdUsuario}', no existe. Operación canselada.";
                response.ValidationResult.Errors.Add(item);
            }

            return response; 
        }


        //public async Task<CommandResponse> Eliminar(Guid id)
        //{
        //    var deleteCommand = new PaisEliminarCommand(id);
        //    return await _mediator.SendCommand(deleteCommand);
        //}

        //public async Task<CommandResponse> Modificar(PaisViewModel modelo)
        //{
        //    var updateCommand = _mapper.Map<PaisModificarCommand>(modelo);
        //    return await _mediator.SendCommand(updateCommand);
        //}

        public async Task<IList<PaisHistoryData>> GetAllHistory(Guid id)
        {
            return PaisHistory.ToJavaScriptCustomerHistory(await _eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
