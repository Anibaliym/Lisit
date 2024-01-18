using App.Application.EventSourcedNormalizers;
using App.Application.Interfaces;
using App.Application.ViewModels.Comuna;
using App.Domain.Commands.Comuna.Commands;
using App.Domain.Core.Mediator;
using App.Domain.Core.Messaging;
using App.Domain.Interfaces;
using App.Infra.Data.Repository.EventSourcing;
using AutoMapper;

namespace App.Application.Services
{
    public class ComunaAppService : IComunaAppService
    {
        private readonly IMapper _mapper;
        private readonly IComunaRepository _comunaRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public ComunaAppService(IMapper mapper, IComunaRepository comunaRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _comunaRepository = comunaRepository;
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

        public async Task<CommandResponse> Crear(ComunaCrearViewModel modelo)
        {
            var createCommand = _mapper.Map<ComunaCrearCommand>(modelo);
            return await _mediator.SendCommand(createCommand);
        }

        public async Task<IList<ComunaHistoryData>> GetAllHistory(Guid id)
        {
            return ComunaHistory.ToJavaScriptCustomerHistory(await _eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
