using App.Application.EventSourcedNormalizers;
using App.Application.Interfaces;
using App.Application.ViewModels.Region;
using App.Domain.Commands.Region.Commands;
using App.Domain.Core.Mediator;
using App.Domain.Core.Messaging;
using App.Domain.Interfaces;
using App.Infra.Data.Repository.EventSourcing;
using AutoMapper;

namespace App.Application.Services
{
    public class RegionAppService : IRegionAppService
    {
        private readonly IMapper _mapper;
        private readonly IRegionRepository _regionRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public RegionAppService(IMapper mapper, IRegionRepository regionRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _regionRepository = regionRepository;
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
            var createCommand = _mapper.Map<RegionCrearCommand>(modelo);
            return await _mediator.SendCommand(createCommand);
        }

        public async Task<IList<RegionHistoryData>> GetAllHistory(Guid id)
        {
            return RegionHistory.ToJavaScriptCustomerHistory(await _eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
