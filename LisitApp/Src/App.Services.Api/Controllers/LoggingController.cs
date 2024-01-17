using App.Application.EventSourcedNormalizers;
using App.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoggingController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IAyudasSocialesAppService _ayudasSocialesAppService;
        private readonly IAsignacionesAppService _asignacionesAppService;
        private readonly IPaisAppService _paisAppService;
        private readonly IRegionAppService _regionAppService;
        private readonly IComunaAppService _comunaAppService;

        public LoggingController(IUsuarioAppService usuarioAppService, IAyudasSocialesAppService ayudasSocialesAppService, IAsignacionesAppService asignacionesAppService, IPaisAppService paisAppService, IRegionAppService regionAppService, IComunaAppService comunaAppService)
        {
            _usuarioAppService = usuarioAppService;
            _ayudasSocialesAppService = ayudasSocialesAppService;
            _asignacionesAppService = asignacionesAppService;
            _paisAppService = paisAppService;
            _regionAppService = regionAppService;
            _comunaAppService = comunaAppService;
        }

        [HttpGet("UsuarioHistory/{id:guid}")]
        public async Task<IList<UsuarioHistoryData>> UsuarioHistory(Guid id)
        {
            return await _usuarioAppService.GetAllHistory(id);
        }

        [HttpGet("AsignacionesHistory/{id:guid}")]
        public async Task<IList<AsignacionesHistoryData>> AsignacionesHistory(Guid id)
        {
            return await _asignacionesAppService.GetAllHistory(id);
        }

        [HttpGet("AyudasSocialesHistory/{id:guid}")]
        public async Task<IList<AyudasSocialesHistoryData>> AyudasSocialesHistory(Guid id)
        {
            return await _ayudasSocialesAppService.GetAllHistory(id);
        }

        [HttpGet("ComunaHistory/{id:guid}")]
        public async Task<IList<ComunaHistoryData>> ComunaHistory(Guid id)
        {
            return await _comunaAppService.GetAllHistory(id);
        }

        [HttpGet("PaisHistory/{id:guid}")]
        public async Task<IList<PaisHistoryData>> PaisHistory(Guid id)
        {
            return await _paisAppService.GetAllHistory(id);
        }

        [HttpGet("RegionHistory/{id:guid}")]
        public async Task<IList<RegionHistoryData>> RegionHistory(Guid id)
        {
            return await _regionAppService.GetAllHistory(id);
        }
    }
}
