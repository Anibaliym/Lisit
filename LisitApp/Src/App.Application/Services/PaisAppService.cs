using App.Application.EventSourcedNormalizers;
using App.Application.Interfaces;
using App.Application.ViewModels.Pais;
using App.Domain.Commands.Pais.Commands;
using App.Domain.Core.Mediator;
using App.Domain.Core.Messaging;
using App.Domain.Interfaces;
using App.Infra.Data.Repository.EventSourcing;
using AutoMapper;

namespace App.Application.Services
{
    public class PaisAppService : IPaisAppService
    {
        private readonly IMapper _mapper;
        private readonly IPaisRepository _paisRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public PaisAppService(IMapper mapper, IPaisRepository paisRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _paisRepository = paisRepository;
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
            var createCommand = _mapper.Map<PaisCrearCommand>(modelo);
            return await _mediator.SendCommand(createCommand);
        }

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
