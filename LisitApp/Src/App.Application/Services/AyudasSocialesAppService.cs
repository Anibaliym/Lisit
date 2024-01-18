using App.Application.EventSourcedNormalizers;
using App.Application.Interfaces;
using App.Application.ViewModels.AyudasSociales;
using App.Domain.Commands.AyudasSociales.Commands;
using App.Domain.Core.Mediator;
using App.Domain.Core.Messaging;
using App.Domain.Interfaces;
using App.Infra.Data.Repository.EventSourcing;
using AutoMapper;

namespace App.Application.Services
{
    public class AyudasSocialesAppService : IAyudasSocialesAppService
    {
        private readonly IMapper _mapper;
        private readonly IAyudasSocialesRepository _ayudasSocialesRepository;

        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public AyudasSocialesAppService(IMapper mapper, IAyudasSocialesRepository ayudasSocialesRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _ayudasSocialesRepository = ayudasSocialesRepository;
            _eventStoreRepository = eventStoreRepository;
            _mediator = mediator;
        }

        public async Task<AyudasSocialesViewModel> BuscaPorId(Guid id)
        {
            return _mapper.Map<AyudasSocialesViewModel>(await _ayudasSocialesRepository.BuscaPorId(id));
        }

        public async Task<CommandResponse> Crear(AyudasSocialesCrearViewModel modelo)
        {
            var createCommand = _mapper.Map<AyudasSocialesCrearCommand>(modelo);
            return await _mediator.SendCommand(createCommand);
        }

        public async Task<IList<AyudasSocialesHistoryData>> GetAllHistory(Guid id)
        {
            return AyudasSocialesHistory.ToJavaScriptCustomerHistory(await _eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<int> Busca_AnioAyudaSocial(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
