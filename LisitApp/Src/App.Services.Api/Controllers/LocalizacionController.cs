using App.Application.Interfaces;
using App.Application.ViewModels.Comuna;
using App.Application.ViewModels.Pais;
using App.Application.ViewModels.Region;
using Microsoft.AspNetCore.Mvc;

namespace App.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class LocalizacionController : ApiController
    {
        private readonly IPaisAppService _paisAppService;
        private readonly IRegionAppService _regionAppService;
        private readonly IComunaAppService _comunaAppService;

        public LocalizacionController(IPaisAppService paisAppService, IRegionAppService regionAppService, IComunaAppService comunaAppService)
        {
            _paisAppService = paisAppService;
            _regionAppService = regionAppService;
            _comunaAppService = comunaAppService;
        }

        [HttpPost("RegistrarPais")]
        public async Task<IActionResult> RegistrarPais(PaisCrearViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _paisAppService.Crear(modelo));
        }

        [HttpPost("RegistrarRegion")]
        public async Task<IActionResult> RegistrarRegion(RegionCrearViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _regionAppService.Crear(modelo));
        }

        [HttpPost("RegistrarComuna")]
        public async Task<IActionResult> RegistrarComuna(ComunaCrearViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _comunaAppService.Crear(modelo));
        }

        [HttpGet("BuscaPorId/{id:guid}")]
        public async Task<PaisViewModel> BuscaPorId(Guid id)
        {
            return await _paisAppService.BuscaPorId(id);
        }
    }
}
