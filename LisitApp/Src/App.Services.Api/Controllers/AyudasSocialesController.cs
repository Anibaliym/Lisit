using App.Application.Interfaces;
using App.Application.ViewModels.Asignaciones;
using App.Application.ViewModels.AyudasSociales;
using Microsoft.AspNetCore.Mvc;

namespace App.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class AyudasSocialesController : ApiController
    {
        private readonly IAyudasSocialesAppService _ayudasSocialesAppService;
        private readonly IAsignacionesAppService _asignacionesAppService;

        public AyudasSocialesController(IAyudasSocialesAppService ayudasSocialesAppService, IAsignacionesAppService asignacionesAppService)
        {
            _ayudasSocialesAppService = ayudasSocialesAppService;
            _asignacionesAppService = asignacionesAppService;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear(AyudasSocialesCrearViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _ayudasSocialesAppService.Crear(modelo));
        }

        [HttpGet("BuscaPorId/{id:guid}")]
        public async Task<AyudasSocialesViewModel> BuscaPorId(Guid id)
        {
            return await _ayudasSocialesAppService.BuscaPorId(id);
        }








        [HttpPost("Crear_Asignacion")]
        public async Task<IActionResult> Crear_Asignacion(AsignacionesCrearViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _asignacionesAppService.Crear(modelo));
        }

        [HttpGet("BuscaPorId_Asignaciones/{id:guid}")]
        public async Task<AsignacionesViewModel> BuscaPorId_Asignaciones(Guid id)
        {
            return await _asignacionesAppService.BuscaPorId(id);
        }
    }
}
