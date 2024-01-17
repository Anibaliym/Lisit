using App.Application.Interfaces;
using App.Application.ViewModels.Asignaciones;
using App.Domain.Commands.Asignaciones.Commands;
using App.Domain.Core.Mediator;
using App.Domain.Core.Messaging;
using App.Domain.Interfaces;
using App.Infra.Data.Repository.EventSourcing;
using AutoMapper;

namespace App.Application.Services
{
    public class AsignacionesAppService : IAsignacionesAppService
    {
        private readonly IMapper _mapper;
        private readonly IAsignacionesRepository _asignacionesRepository;

        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public AsignacionesAppService(IMapper mapper, IAsignacionesRepository asignacionesRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _asignacionesRepository = asignacionesRepository;
            _eventStoreRepository = eventStoreRepository;
            _mediator = mediator;
        }

        public async Task<AsignacionesViewModel> BuscaPorId(Guid id)
        {
            return _mapper.Map<AsignacionesViewModel>(await _asignacionesRepository.BuscaPorId(id));
        }

        public async Task<CommandResponse> Crear(AsignacionesCrearViewModel modelo)
        {
            var createCommand = _mapper.Map<AsignacionesCrearCommand>(modelo);
            return await _mediator.SendCommand(createCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
